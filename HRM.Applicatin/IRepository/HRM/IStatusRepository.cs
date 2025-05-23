using HRM.Domain;

namespace HRM.Applicatin
{
    public interface IStatusRepository
    {
        Task<Status> AddStatusAsync(Status status);
        Task<Status> UpdateStatusAsync(int statuseId, Status status);
        Task<bool> DeleteStatusAsync(int statuseId);
        Task<Status> GetStatusByIdAsync(int id);
        //Task<List<LeaveType>> GetLeaveTypeByName(string name);
        Task<IEnumerable<Status>> GetStatusAsync();
    }
}