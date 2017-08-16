using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Models
{
    public enum eFea
    {
        QLCG,
        QLCH,
        QLCTGV,
        QLCTHV,
        QLCTLGD,
        QLHV,
        QLKH,
        QLLGD,
        QLNKGD,
        QLTTT,
        QLTK,
        QLPQ,
        QLVT,
        QLHVV
    }

    public enum eAction
    {
        Delete, Add, Edit, Search
    }

    public enum eRole
    {
        SuperAdmin = 0,
        Admin = 1,
        User = 2,
        Guest = 3
    }
    public class Permission
    {
        public AccountObject Account { get; set; }
        public List<PermisstionObject> ListPermission { get; set; }

        public Permission()
        {
            var Account = new Login().GetAccount();
            if (Account != null)
            {
                Account.RoleJoin = new RoleBCL().GetByRoleId((Guid)Account.RoleId);
                ListPermission = new PermisstionBCL().GetJoin().Where(q => q.UserId == Account.UserId).ToList();
            }
        }

        public Permission(AccountObject acc)
        {
            // TODO: Complete member initialization
            this.Account = acc;
            if (Account != null)
            {
                Account.RoleJoin = new RoleBCL().GetByRoleId((Guid)Account.RoleId);
                ListPermission = new PermisstionBCL().GetJoin().Where(q => q.UserId == Account.UserId).ToList();
            }
        }

        public bool IsAllow(eAction action, eFea Fea)
        {
            if (Account == null) return false;
            if (GetRole() == eRole.SuperAdmin) return true;
            switch (action)
            {
                case eAction.Delete:
                    return ListPermission.Any(q => q.F_DELETE == true && q.FeaId.Trim().ToUpper() == Fea.ToString());
                case eAction.Add:
                    return ListPermission.Any(q => q.F_ADD == true && q.FeaId.Trim().ToUpper() == Fea.ToString());
                case eAction.Edit:
                    return ListPermission.Any(q => q.F_EDIT == true && q.FeaId.Trim().ToUpper() == Fea.ToString());
                case eAction.Search:
                    return ListPermission.Any(q => q.F_SEARCH == true && q.FeaId.Trim().ToUpper() == Fea.ToString());
                default:
                    return false;
            }
        }

        public bool Have(eFea fea)
        {
            if (Account == null) return false;
            if (GetRole() == eRole.SuperAdmin) return true;
            return ListPermission.Any(q => q.FeaId.Trim().ToUpper() == fea.ToString());
        }

        public eRole GetRole()
        {
            if (Account == null) return eRole.Guest;
            switch (Account.RoleJoin.RName.Trim().ToLower())
            {
                case "superadmin":
                    return eRole.SuperAdmin;
                case "admin":
                    return eRole.Admin;
                case "user":
                    return eRole.User;
                default:
                    return eRole.Guest;
            }
        }
    }
}