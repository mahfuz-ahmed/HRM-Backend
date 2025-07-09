
using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class BankInformation
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        public required string BankName { get; set; }
        public required string BranceName { get; set; }
        public int AccountNumber { get; set; }
        public required int EntryUseID { get; set; }
        public required DateTime EntryDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
