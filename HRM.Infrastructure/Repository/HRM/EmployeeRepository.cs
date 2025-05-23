using HRM.Applicatin;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var updateEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (updateEmployee is not null)
            {
                updateEmployee.FullName = employee.FullName;
                updateEmployee.Email = employee.Email;
                updateEmployee.IsActive = employee.IsActive;
                updateEmployee.IsAdmin = employee.IsAdmin;
                updateEmployee.JoinDate = employee.JoinDate;
                updateEmployee.EntryUseID = employee.EntryUseID;
                updateEmployee.EntryDate = employee.EntryDate;
                updateEmployee.UpdateUserID = employee.UpdateUserID;
                updateEmployee.UpdateDate = employee.UpdateDate;
                await dbContext.SaveChangesAsync();
                return updateEmployee;
            }
            return employee;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var deleteEmployee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteEmployee is not null)
            {
                dbContext.Employees.Remove(deleteEmployee);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeeByName(string name)
        {
            return await dbContext.Employees.Where(x => x.FullName == name).ToListAsync();
        }
    }
}
