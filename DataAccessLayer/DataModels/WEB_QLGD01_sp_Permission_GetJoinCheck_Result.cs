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
    
    public partial class WEB_QLGD01_sp_Permission_GetJoinCheck_Result
    {
        public string FeaName { get; set; }
        public Nullable<bool> IsdeletedFedId { get; set; }
        public System.Guid PerID { get; set; }
        public Nullable<bool> F_ADD { get; set; }
        public Nullable<bool> F_EDIT { get; set; }
        public Nullable<bool> F_DELETE { get; set; }
        public Nullable<bool> F_SEARCH { get; set; }
        public string FeaId { get; set; }
        public System.Guid UserId { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsdeletedAccount { get; set; }
        public Nullable<System.Guid> RoleId { get; set; }
    }
}