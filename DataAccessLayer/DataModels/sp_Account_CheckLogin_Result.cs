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
    
    public partial class sp_Account_CheckLogin_Result
    {
        public System.Guid UserId { get; set; }
        public string FullName { get; set; }
        public string PassWord { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
        public Nullable<System.Guid> RoleId { get; set; }
    }
}
