using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class RoleBCL
    {

        public bool Insert(RoleObject ob)
        {
            return new RoleDao().Insert(ob);
        }


        public bool Update(RoleObject ob)
        {
            return new RoleDao().Update(ob);
        }


        public List<RoleObject> GetAll()
        {
            return new RoleDao().GetAll();
        }
        public RoleObject GetAllJoin()
        {
            return new RoleDao().GetAllJoin();
        }

        public RoleObject GetByRoleId(Guid ID)
        {
            return new RoleDao().GetByRoleId(ID);
        }


        public bool Delete(Guid ID)
        {
            return new RoleDao().Delete(ID);
        }



        
    }
}
