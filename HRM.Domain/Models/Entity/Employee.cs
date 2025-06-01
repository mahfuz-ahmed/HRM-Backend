
using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public required int UserID { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
        public required DateTime JoinDate { get; set; }
        public required int EntryUserID { get; set; }
        public required DateTime EntryDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
