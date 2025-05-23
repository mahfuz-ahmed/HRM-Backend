using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class Policies
    {
        public int ID { get; set; }

        public required int DepartmentID { get; set; }

        public required string Description { get; set; }

        public required DateTime CreatedDate { get; set; }

        // Audit fields
        public required int EntryUseID { get; set; }

        public required DateTime EntryDate { get; set; }

        public int? UpdateUserID { get; set; }

        public DateTime? UpdateDate { get; set; }

        [JsonIgnore]
        public Department? Department { get; set; }
    }
}
