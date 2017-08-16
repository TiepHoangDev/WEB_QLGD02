
using System;
namespace WCF.BussinessObject.Objects
{
    public class ExpertsDetailtObjects
    {
        public Guid ExId { get; set; }
        public Nullable<Guid> ExpertId { get; set; }
        public Nullable<Guid> CoId { get; set; }
        public string Description { get; set; }
        public ExpertsObjects ExpertsJoin { get; set; }
        public CoursesObjects CoursesJoin { get; set; }
    }
}
