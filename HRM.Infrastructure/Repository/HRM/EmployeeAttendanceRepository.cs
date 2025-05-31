using HRM.Applicatin;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure
{
    public class EmployeeAttendanceRepository(AppDbContext dbContext) : IEmployeeAttendanceRepository
    {
        public async Task<EmployeeAttendance> AddEmployeeAttendanceAsync(EmployeeAttendance employeeAttendance)
        {
            dbContext.EmployeeAttendance.Add(employeeAttendance);
            await dbContext.SaveChangesAsync();
            return employeeAttendance;
        }

        public async Task<EmployeeAttendance> UpdateHolidaysAsync(int id, EmployeeAttendance employeeAttendance)
        {
            var updateEmployeeAttendance = await dbContext.EmployeeAttendance.FirstOrDefaultAsync(x => x.ID == id);
            if (updateEmployeeAttendance is not null)
            {
                updateEmployeeAttendance.EmployeeId = employeeAttendance.EmployeeId;
                updateEmployeeAttendance.AttendanceStatusID = employeeAttendance.AttendanceStatusID;
                updateEmployeeAttendance.AttendanceDate = employeeAttendance.AttendanceDate;
                updateEmployeeAttendance.CheckIn = employeeAttendance.CheckIn;
                updateEmployeeAttendance.CheckOut = employeeAttendance.CheckOut;
                updateEmployeeAttendance.Late = employeeAttendance.Late;
                updateEmployeeAttendance.Break = employeeAttendance.Break;
                updateEmployeeAttendance.ProductionHours = employeeAttendance.ProductionHours;
                updateEmployeeAttendance.IsAdmin = employeeAttendance.IsAdmin;
                updateEmployeeAttendance.EntryUseID = employeeAttendance.EntryUseID;
                updateEmployeeAttendance.EntryDate = employeeAttendance.EntryDate;
                updateEmployeeAttendance.UpdateUserID = employeeAttendance.UpdateUserID;
                updateEmployeeAttendance.UpdateDate = employeeAttendance.UpdateDate;
                await dbContext.SaveChangesAsync();
                return updateEmployeeAttendance;
            }
            return employeeAttendance;
        }

        public async Task<bool> DeleteEmployeeAttendanceAsync(int id)
        {
            var deleteEmployeeAttendance = await dbContext.EmployeeAttendance.FirstOrDefaultAsync(x => x.ID == id);

            if (deleteEmployeeAttendance is not null)
            {
                dbContext.EmployeeAttendance.Remove(deleteEmployeeAttendance);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<EmployeeAttendance> GetEmployeeAttendanceByIdAsync(int id)
        {
            return await dbContext.EmployeeAttendance.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<EmployeeAttendance>> GetEmployeeAttendanceAsync()
        {
            return await dbContext.EmployeeAttendance.ToListAsync();
        }

        public Task<EmployeeAttendance> UpdateEmployeeAttendanceAsync(int employeeAttendanceId, EmployeeAttendance employeeAttendance)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeAttendance>> GetEmployeeAttendanceByName(string name)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<EmployeeAttendance>> GetEmployeeAttendanceByName(string name)
        //{
        //    return await dbContext.EmployeeAttendance.Where(x => x.HolidayName == name).ToListAsync();
        //}

        public void ConflictMethod()
        {

        }
    }
}
