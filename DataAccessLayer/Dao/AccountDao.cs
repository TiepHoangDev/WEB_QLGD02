using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class AccountDao
    {

        public bool Insert(AccountObject ob)
        {
            if (GetAll().Find(q => q.Username.Trim().ToLower() == ob.Username) != null) return false;
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Account_INSERT(ob.UserId, ob.FullName, ob.PassWord, ob.Username, ob.Email, ob.Phone, ob.Description, ob.Isdeleted, ob.RoleId) > 0;
        }


        public bool Update(AccountObject ob)
        {
            if (GetAll().Find(q => q.Username.Trim().ToLower() == ob.Username) != null) return false;
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_Account_UPDATE(ob.UserId, ob.FullName, ob.PassWord, ob.Username, ob.Email, ob.Phone, ob.Description, ob.Isdeleted, ob.RoleId) > 0;
        }


        public List<AccountObject> GetAll()
        {
            List<AccountObject> lst = new List<AccountObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Account_GetAll();
            foreach (var item in list)
            {
                if (item.Isdeleted == true) continue;
                AccountObject ob = new AccountObject();
                ob.UserId = item.UserId; ob.FullName = item.FullName; ob.PassWord = item.PassWord; ob.Username = item.Username; ob.Email = item.Email; ob.Phone = item.Phone; ob.Description = item.Description; ob.Isdeleted = item.Isdeleted; ob.RoleId = item.RoleId;
                lst.Add(ob);
            }
            return lst;
        }

        public List<AccountObject> GetJoin()
        {
            List<AccountObject> lst = new List<AccountObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.WEB_QLGD01_sp_Account_GetJoin();
            foreach (var item in list)
            {
                if (item.IsdeletedAccount == true || item.IsdeletedRole == true) continue;
                AccountObject ob = new AccountObject();
                ob.UserId = item.UserId; ob.FullName = item.FullName; ob.PassWord = item.PassWord; ob.Username = item.Username; ob.Email = item.Email; ob.Phone = item.Phone; ob.Description = item.Description; ob.Isdeleted = item.IsdeletedAccount; ob.RoleId = item.RoleId;
                ob.RoleJoin = new RoleObject()
                {
                    Isdeleted = item.IsdeletedRole,
                    RName = item.RName,
                    RoleId = item.RoleId
                };
                lst.Add(ob);
            }
            return lst;
        }

        public AccountObject GetByUserId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_Account_GetByUserId(ID);
            foreach (var item in list)
            {
                AccountObject obj = new AccountObject();
                obj.UserId = item.UserId; obj.FullName = item.FullName; obj.PassWord = item.PassWord; obj.Username = item.Username; obj.Email = item.Email; obj.Phone = item.Phone; obj.Description = item.Description; obj.Isdeleted = item.Isdeleted; obj.RoleId = item.RoleId;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var obj = GetByUserId(ID);
            if (obj == null) return false;
            obj.Isdeleted = true;
            return Update(obj);
        }

        public AccountObject CheckLogin(AccountObject obj)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_Account_CheckLogin(obj.Username, obj.PassWord);
            foreach (var item in list)
            {
                AccountObject ob = new AccountObject();
                ob.UserId = item.UserId; ob.FullName = item.FullName; ob.PassWord = item.PassWord; ob.Username = item.Username; ob.Email = item.Email; ob.Phone = item.Phone; ob.Description = item.Description; ob.Isdeleted = item.Isdeleted; ob.RoleId = item.RoleId;
                return ob;
            }
            return null;
        }
    }
}
