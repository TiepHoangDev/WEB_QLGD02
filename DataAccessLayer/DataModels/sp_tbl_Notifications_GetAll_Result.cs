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
    
    public partial class sp_tbl_Notifications_GetAll_Result
    {
        public System.Guid notificationsID { get; set; }
        public string title { get; set; }
        public string Content { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
        public string FullNameUser1 { get; set; }
        public string FullNameUser2 { get; set; }
    }
}