//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_S07_Student
    {
        public tbl_S07_Student()
        {
            this.tbl_S07_CoursesStudentDetailt = new HashSet<tbl_S07_CoursesStudentDetailt>();
            this.tbl_S07_StudentDetailt = new HashSet<tbl_S07_StudentDetailt>();
        }
    
        public System.Guid StudetId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual ICollection<tbl_S07_CoursesStudentDetailt> tbl_S07_CoursesStudentDetailt { get; set; }
        public virtual ICollection<tbl_S07_StudentDetailt> tbl_S07_StudentDetailt { get; set; }
    }
}
