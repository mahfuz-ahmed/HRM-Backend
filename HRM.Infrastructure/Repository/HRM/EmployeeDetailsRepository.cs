using HRM.Applicatin;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;


namespace HRM.Infrastructure
{
    public class EmployeeDetailsRepository(AppDbContext dbContext) : IEmployeeDetailsRepository
    {
        public async Task<EmployeeDetails> AddEmployeeDetailsAsync(EmployeeDetails employeeDetails)
        {
            dbContext.EmployeeDetails.Add(employeeDetails);
            await dbContext.SaveChangesAsync();
            return employeeDetails;
        }

        public async Task<EmployeeDetails> UpdateEmployeeDetailsAsync(int id, EmployeeDetails employeeDetails)
        {
            var updateEmployeeDetails = await dbContext.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (updateEmployeeDetails is not null)
            {
                updateEmployeeDetails.EmployeeID = employeeDetails.EmployeeID;
                updateEmployeeDetails.FirstName = employeeDetails.FirstName;
                updateEmployeeDetails.LastName = employeeDetails.LastName;
                updateEmployeeDetails.Gender = employeeDetails.Gender;
                updateEmployeeDetails.BirthDate = employeeDetails.BirthDate;
                updateEmployeeDetails.NIDNumber = employeeDetails.NIDNumber;
                updateEmployeeDetails.DepartmentID = employeeDetails.DepartmentID;
                updateEmployeeDetails.DesignationID = employeeDetails.DesignationID;
                updateEmployeeDetails.PresentAddress = employeeDetails.PresentAddress;
                updateEmployeeDetails.PermanentAddress = employeeDetails.PermanentAddress;
                updateEmployeeDetails.Image = employeeDetails.Image;
                updateEmployeeDetails.About = employeeDetails.About;
                updateEmployeeDetails.Signature = employeeDetails.Signature;
                updateEmployeeDetails.EntryUseID = employeeDetails.EntryUseID;
                updateEmployeeDetails.EntryDate = employeeDetails.EntryDate;
                updateEmployeeDetails.UpdateUserID = employeeDetails.UpdateUserID;
                updateEmployeeDetails.UpdateDate = employeeDetails.UpdateDate;
                await dbContext.SaveChangesAsync();
                return updateEmployeeDetails;
            }
            return employeeDetails;
        }

        public async Task<bool> DeleteEmployeeDetailsAsync(int id)
        {
            var deleteEmployeeDetails = await dbContext.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (deleteEmployeeDetails is not null)
            {
                dbContext.EmployeeDetails.Remove(deleteEmployeeDetails);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<EmployeeDetails> GetEmployeeDetailsByIdAsync(int id)
        {
            return await dbContext.EmployeeDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<EmployeeDetails>> GetEmployeeDetailsAsync()
        {
            return await dbContext.EmployeeDetails.ToListAsync();
        }
    }
}
