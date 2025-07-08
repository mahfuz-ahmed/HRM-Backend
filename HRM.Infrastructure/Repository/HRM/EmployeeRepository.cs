using HRM.Applicatin;
using HRM.Applicatin.Service;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HRM.Infrastructure
{
    public class EmployeeRepository: IEmployeeRepository
    {

        private readonly AppDbContext _dbContext;
        private readonly IRedisCacheService _cacheService;
        //private const string CacheKeyPrefix = "employee_";
        //private const string AllEmployeeCacheKey = "All_Employee";


        public EmployeeRepository(AppDbContext dbContext, IRedisCacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();

            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(employee.Id);
            // Cache the newly added doctor
            await _cacheService.SetAsync(cacheKey, employee, TimeSpan.FromHours(1));

            // Invalidate all doctors cache since data changed
            await _cacheService.RemoveAsync(cacheKey);

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var updateEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (updateEmployee is not null)
            {
                updateEmployee.FullName = employee.FullName;
                updateEmployee.Email = employee.Email;
                updateEmployee.IsActive = employee.IsActive;
                updateEmployee.IsAdmin = employee.IsAdmin;
                updateEmployee.JoinDate = employee.JoinDate;
                updateEmployee.EntryUserID = employee.EntryUserID;
                updateEmployee.EntryDate = employee.EntryDate;
                updateEmployee.UpdateUserID = employee.UpdateUserID;
                updateEmployee.UpdateDate = employee.UpdateDate;
                await _dbContext.SaveChangesAsync();

                return updateEmployee;
            }
            //await _cacheService.SetAsync(CacheKeyPrefix + employee.Id, updateEmployee, TimeSpan.FromHours(1));
            var getAllCache = CacheKeyHelper<Employee>.GetAllKey();
            await _cacheService.RemoveAsync(getAllCache);

            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var deleteEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteEmployee is not null)
            {
                _dbContext.Employees.Remove(deleteEmployee);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Employee> EmployeeGetDataAsync(int id)
        {
            // Try to get data from cache

            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(id);


            var employeeCache = await _cacheService.GetAsync<Employee>(cacheKey);

            if (employeeCache != null)
            {
                return employeeCache;
            }

            // If not found in cache, get from database
            var employeeDb  = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employeeDb != null)
            {
                // Store in cache for future use
                await _cacheService.SetAsync(cacheKey, employeeDb, TimeSpan.FromHours(1));
            }
            return employeeDb;

            //return await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Employee>> EmployeeGetAllDataAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
