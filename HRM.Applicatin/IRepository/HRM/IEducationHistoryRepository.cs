using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IEducationHistoryRepository
    {
        Task<EducationHistory> AddEducationHistoryAsync(EducationHistory educationHistory);
        Task<EducationHistory> UpdateEducationHistoryAsync(int educationHistoryId, EducationHistory educationHistory);
        Task<bool> DeleteEducationHistoryAsync(int educationHistoryId);
        Task<EducationHistory> GetEducationHistoryByIdAsync(int id);
        Task<List<EducationHistory>> GetEducationHistoryByName(string name);
        Task<IEnumerable<EducationHistory>> GetEducationHistoryAsync();
    }
}
