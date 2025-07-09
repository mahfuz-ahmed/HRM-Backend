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

        public EmployeeRepository(AppDbContext dbContext, IRedisCacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);

            var addedEmployee = await _dbContext.SaveChangesAsync();

            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(employee.Id);

            await _cacheService.SetAsync(cacheKey, employee, TimeSpan.FromHours(1));

            await _cacheService.RemoveAsync(CacheKeyHelper<Employee>.GetAllKey());

            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var updateEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(id);

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

                await _cacheService.SetAsync(cacheKey, updateEmployee, TimeSpan.FromHours(1));
            }

            await _cacheService.RemoveAsync(CacheKeyHelper<Employee>.GetAllKey());

            return updateEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var deleteEmployee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(id);

            if (deleteEmployee is not null)
            {
                _dbContext.Employees.Remove(deleteEmployee);
                await _cacheService.RemoveAsync(cacheKey);
                await _cacheService.RemoveAsync(CacheKeyHelper<Employee>.GetAllKey());

                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Employee> EmployeeGetDataAsync(int id)
        {

            var cacheKey = CacheKeyHelper<Employee>.GetByIdKey(id);

            var employeeCache = await _cacheService.GetAsync<Employee>(cacheKey);

            if (employeeCache != null)
            {
                return employeeCache;
            }

            var employeeDb  = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeDb != null)
            {
                await _cacheService.SetAsync(cacheKey, employeeDb, TimeSpan.FromHours(1));
            }
            return employeeDb;
        }

        public async Task<List<Employee>> EmployeeGetAllDataAsync()
        {

            var cacheKey = CacheKeyHelper<Employee>.GetAllKey();
            var getAllFromCache = await _cacheService.GetAsync<List<Employee>>(cacheKey);
            if(getAllFromCache != null)
            {
                return getAllFromCache;
            }

            var getAllFromDb = await _dbContext.Employees.ToListAsync();
            if(getAllFromDb != null)
            {
            await _cacheService.SetAsync(cacheKey,getAllFromDb,TimeSpan.FromHours(1));

            }

            return getAllFromDb;
        }
    }
}
