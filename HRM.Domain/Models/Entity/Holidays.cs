using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Domain
{
    public class Holidays
    {
        public int ID { get; set; } 

        public required string Title { get; set; }

        public DateTime Date { get; set; }

        public required string HolidayName { get; set; }

        public required string Description { get; set; }

        public bool IsActive { get; set; }

        // Audit fields
        public required int EntryUseID { get; set; }

        public required DateTime EntryDate { get; set; }

        public int? UpdateUserID { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
