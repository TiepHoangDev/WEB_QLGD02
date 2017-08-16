using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WCF.BussinessObject.Objects
{
    public class CoursesStudentDetailtObject
    {
        public System.Guid ScsId { get; set; }
        public Nullable<System.Guid> StudetId { get; set; }
        public Nullable<System.Guid> CJId { get; set; }
        public string Description { get; set; }

        public StudentObjects StudentJoin { get; set; }
        public CoursesJournalObjects CoursesJournalJoin { get; set; }
    }
}
