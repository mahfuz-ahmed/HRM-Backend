using HRM.Domain;


namespace HRM.Applicatin
{
    public interface IDesignationRepository
    {
        Task<Designation> AddDesignationAsync(Designation designation);
        Task<Designation> UpdateDesignationAsync(int designationId, Designation designation);
        Task<bool> DeleteDesignationAsync(int designationId);
        Task<Designation> GetDesignationByIdAsync(int id);
        Task<List<Designation>> GetDesignationByName(string name);
        Task<IEnumerable<Designation>> GetDesignationAsync();
    }
}
