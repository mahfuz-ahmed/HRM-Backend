using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class LeaveRequest
    {
        public int ID { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public required string Reason { get; set; } 

        public int StatusID { get; set; }

        public int RemainingLeave { get; set; }

        public int ApprovalId { get; set; }

        public DateTime ApprovalDate { get; set; }

        public required string ApprovalComments { get; set; }

        public bool IsAdmin { get; set; }

        // Audit fields
        public required int EntryUseID { get; set; }

        public required DateTime EntryDate { get; set; }

        public int? UpdateUserID { get; set; }

        public DateTime? UpdateDate { get; set; }

        [JsonIgnore]
        public Employee? Employee { get; set; }

        [JsonIgnore]
        public LeaveType? LeaveType { get; set; }

        [JsonIgnore]
        public Status? Status { get; set; }
    }
}
