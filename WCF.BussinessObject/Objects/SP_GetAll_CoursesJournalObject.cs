using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BussinessObject.Objects
{
   public class SP_GetAll_CoursesJournalObject
    {
        public System.Guid CJId { get; set; }
        public string CourseName { get; set; }
        public Nullable<System.DateTime> DayOf { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
    }
}
