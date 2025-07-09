﻿using System.Text.Json.Serialization;

namespace HRM.Domain
{
    public class EducationHistory
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        public required string Inistute { get; set; }
        public required string Subject { get; set; }
        public required int PassingYear { get; set; }
        public required int EntryUseID { get; set; }
        public required DateTime EntryDate { get; set; }
        public int? UpdateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
