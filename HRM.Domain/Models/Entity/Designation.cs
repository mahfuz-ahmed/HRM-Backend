using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class Designation
    {
        public int ID { get; set; }
        public required int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public required string DesignationName { get; set; }
        public required string DesignationCode { get; set; }
        public bool IsActive { get; set; }
        public required int EntryUseID { get; set; }
        public required DateTime EntryDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
