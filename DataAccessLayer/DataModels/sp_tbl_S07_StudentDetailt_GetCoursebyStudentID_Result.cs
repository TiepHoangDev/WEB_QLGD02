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
    
    public partial class sp_tbl_S07_StudentDetailt_GetCoursebyStudentID_Result
    {
        public System.Guid StdId { get; set; }
        public Nullable<System.Guid> StudetId { get; set; }
        public Nullable<System.Guid> CoId { get; set; }
        public string Description { get; set; }
        public Nullable<bool> StatusSC { get; set; }
        public string FullName { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}