
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class RoleDao
    {

        public bool Insert(RoleObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Role_INSERT(ob.RoleId, ob.RName, ob.Isdeleted) > 0;
        }


        public bool Update(RoleObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Role_UPDATE(ob.RoleId, ob.RName, ob.Isdeleted) > 0;
        }


        public List<RoleObject> GetAll()
        {
            List<RoleObject> lst = new List<RoleObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Role_GetAll();
            foreach (var item in list)
            {
                RoleObject ob = new RoleObject();
                ob.RoleId = item.RoleId; ob.RName = item.RName; ob.Isdeleted = item.Isdeleted;
                lst.Add(ob);
            }
            return lst;
        }
        public RoleObject GetAllJoin()
        {
            RoleObject lst = new RoleObject();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Role_GetAll();
            foreach (var item in list)
            {
                RoleObject ob = new RoleObject();
                ob.RoleId = item.RoleId; ob.RName = item.RName; ob.Isdeleted = item.Isdeleted;
                return lst;
            }
            return null;
        }

        public RoleObject GetByRoleId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Role_GetByRoleId(ID);
            foreach (var item in list)
            {
                RoleObject obj = new RoleObject();
                obj.RoleId = item.RoleId; obj.RName = item.RName; obj.Isdeleted = item.Isdeleted;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var obj = GetByRoleId(ID);
            obj.Isdeleted = true;
            Update(obj);
            return true;
        }


    }
}
