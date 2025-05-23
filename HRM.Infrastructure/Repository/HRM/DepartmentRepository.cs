using HRM.Applicatin;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        public async Task<Department> AddDepartmentAsync(Department department)
        {
            dbContext.Department.Add(department);
            await dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(int id, Department department)
        {
            var updateDepartment = await dbContext.Department.FirstOrDefaultAsync(x => x.Id == id);
            if (updateDepartment is not null)
            {
                updateDepartment.DepartmentCode = department.DepartmentCode;
                updateDepartment.DepartmentName = department.DepartmentName;
                updateDepartment.IsActive = department.IsActive;
                updateDepartment.EntryUseID = department.EntryUseID;
                updateDepartment.EntryDate = department.EntryDate;
                updateDepartment.UpdateUserID = department.UpdateUserID;
                updateDepartment.UpdateDate = department.UpdateDate;
                await dbContext.SaveChangesAsync();
                return updateDepartment;
            }
            return department;
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var deleteDepartment = await dbContext.Department.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteDepartment is not null)
            {
                dbContext.Department.Remove(deleteDepartment);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await dbContext.Department.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            return await dbContext.Department.ToListAsync();
        }

        public async Task<List<Department>> GetDepartmentByName(string name)
        {
            return await dbContext.Department.Where(x => x.DepartmentName == name).ToListAsync();
        }
    }
}
