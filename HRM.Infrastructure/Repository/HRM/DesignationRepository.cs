using HRM.Applicatin;
using HRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure
{
    public class DesignationRepository(AppDbContext dbContext) : IDesignationRepository
    {
        public async Task<Designation> AddDesignationAsync(Designation designation)
        {
            dbContext.Designation.Add(designation);
            await dbContext.SaveChangesAsync();
            return designation;
        }

        public async Task<Designation> UpdateDesignationAsync(int id, Designation designation)
        {
            var updateDesignation = await dbContext.Designation.FirstOrDefaultAsync(x => x.ID == id);

            if (updateDesignation is not null)
            {
                updateDesignation.DepartmentID = designation.DepartmentID;
                updateDesignation.DesignationName = designation.DesignationName;
                updateDesignation.IsActive = designation.IsActive;
                updateDesignation.EntryUseID = designation.EntryUseID;
                updateDesignation.EntryDate = designation.EntryDate;
                updateDesignation.UpdateUserID = designation.UpdateUserID;
                updateDesignation.UpdateDate = designation.UpdateDate;
                await dbContext.SaveChangesAsync();
                return updateDesignation;
            }
            return designation;
        }

        public async Task<bool> DeleteDesignationAsync(int id)
        {
            var deleteDesignation = await dbContext.Designation.FirstOrDefaultAsync(x => x.ID == id);

            if (deleteDesignation is not null)
            {
                dbContext.Designation.Remove(deleteDesignation);
                return await dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Designation> GetDesignationByIdAsync(int id)
        {
            return await dbContext.Designation.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<IEnumerable<Designation>> GetDesignationAsync()
        {
            return await dbContext.Designation.ToListAsync();
        }

        public async Task<List<Designation>> GetDesignationByName(string name)
        {
            return await dbContext.Designation.Where(x => x.DesignationName == name).ToListAsync();
        }
    }
}
