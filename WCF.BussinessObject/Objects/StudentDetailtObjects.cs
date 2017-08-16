using System;
namespace WCF.BussinessObject.Objects
{
    public class StudentDetailtObjects
    {
        public Guid StdId { get; set; }
        public Nullable<Guid> StudetId { get; set; }
        public Nullable<Guid> CoId { get; set; }
        public string Description { get; set; }
        public StudentObjects StudentJoin { get; set; }
        public CoursesObjects CoursesJoin { get; set; }
    }
}
