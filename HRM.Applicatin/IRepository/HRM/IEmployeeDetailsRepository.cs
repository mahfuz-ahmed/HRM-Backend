using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IEmployeeDetailsRepository
    {
        Task<EmployeeDetails> AddEmployeeDetailsAsync(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> UpdateEmployeeDetailsAsync(int employeeDetailsId, EmployeeDetails employeeDetails);
        Task<bool> DeleteEmployeeDetailsAsync(int employeeDetailsId);
        Task<EmployeeDetails> GetEmployeeDetailsByIdAsync(int id);
        Task<IEnumerable<EmployeeDetails>> GetEmployeeDetailsAsync();
    }
}