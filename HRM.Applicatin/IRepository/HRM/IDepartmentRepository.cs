using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IDepartmentRepository
    {
        Task<Department> AddDepartmentAsync(Department department);
        Task<Department> UpdateDepartmentAsync(int departmentId, Department department);
        Task<bool> DeleteDepartmentAsync(int departmentId);
        Task<Department> GetDepartmentByIdAsync(int id);
        Task<List<Department>> GetDepartmentByName(string name);
        Task<IEnumerable<Department>> GetDepartmentsAsync();
    }
}
