using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int employeeId, Employee employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<Employee> EmployeeGetDataAsync(int id);
        Task<List<Employee>> EmployeeGetAllDataAsync();
    }
}
