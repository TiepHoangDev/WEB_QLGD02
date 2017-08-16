
using System;
namespace WCF.BussinessObject.Objects
{
    public class CoursesJournalObjects
    {
        public Guid CJId { get; set; }
        public Nullable<Guid> CoId { get; set; }
        public Nullable<DateTime> DayOf { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public CoursesObjects CoursesJoin { get; set; }
    }
}
