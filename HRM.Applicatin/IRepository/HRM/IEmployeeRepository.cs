using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int employeeId, Employee employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetEmployeeByName(string name);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}
