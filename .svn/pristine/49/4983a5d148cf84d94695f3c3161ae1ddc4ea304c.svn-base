
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class PermisstionDao
    {

        public bool Insert(PermisstionObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Permisstion_INSERT(ob.PerID, ob.F_ADD, ob.F_EDIT, ob.F_DELETE, ob.F_SEARCH, ob.FeaId, ob.UserId) > 0;
        }


        public bool Update(PermisstionObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Permisstion_UPDATE(ob.PerID, ob.F_ADD, ob.F_EDIT, ob.F_DELETE, ob.F_SEARCH, ob.FeaId, ob.UserId) > 0;
        }


        public List<PermisstionObject> GetAll()
        {
            List<PermisstionObject> lst = new List<PermisstionObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Permisstion_GetAll();
            foreach (var item in list)
            {
                PermisstionObject ob = new PermisstionObject();
                ob.PerID = item.PerID; ob.F_ADD = item.F_ADD; ob.F_EDIT = item.F_EDIT; ob.F_DELETE = item.F_DELETE; ob.F_SEARCH = item.F_SEARCH; ob.FeaId = item.FeaId; ob.UserId = item.UserId;
                lst.Add(ob);
            }
            return lst;
        }

        public PermisstionObject GetByPerID(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Permisstion_GetByPerID(ID);
            foreach (var item in list)
            {
                PermisstionObject obj = new PermisstionObject();
                obj.PerID = item.PerID; obj.F_ADD = item.F_ADD; obj.F_EDIT = item.F_EDIT; obj.F_DELETE = item.F_DELETE; obj.F_SEARCH = item.F_SEARCH; obj.FeaId = item.FeaId; obj.UserId = item.UserId;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Permisstion_DELETE(ID) > 0;
        }

        public List<PermisstionObject> GetJoin()
        {
            List<PermisstionObject> lst = new List<PermisstionObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.WEB_QLGD01_sp_Permission_GetJoin();
            foreach (var item in list)
            {
                PermisstionObject ob = new PermisstionObject();
                ob.PerID = item.PerID; ob.F_ADD = item.F_ADD; ob.F_EDIT = item.F_EDIT; ob.F_DELETE = item.F_DELETE; ob.F_SEARCH = item.F_SEARCH; ob.FeaId = item.FeaId; ob.UserId = item.UserId;
                ob.FeaJoin = new FeaIdObject()
                {
                    FeaId = item.FeaId,
                    FeaName = item.FeaName,
                    Isdeleted = item.IsdeletedFedId
                };
                ob.AccountJoin = new AccountObject
                {
                    Description = item.Description,
                    Email = item.Email,
                    FullName = item.FullName,
                    Isdeleted = item.IsdeletedAccount,
                    PassWord = item.PassWord,
                    Phone = item.Phone,
                    RoleId = item.RoleId,
                    UserId = item.UserId,
                    Username = item.Username
                };
                lst.Add(ob);
            }
            return lst;
        }
    }
}
