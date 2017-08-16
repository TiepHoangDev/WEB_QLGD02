using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class AccountBCL
    {

        public bool Insert(AccountObject ob)
        {
            if (GetAll().Find(q => q.Username.Trim().ToLower().Equals(ob.Username)) != null) return false;
            return new AccountDao().Insert(ob);
        }


        public bool Update(AccountObject ob)
        {
            return new AccountDao().Update(ob);
        }


        public List<AccountObject> GetAll()
        {
            return new AccountDao().GetAll();
        }

        public List<AccountObject> GetJoin()
        {
            return new AccountDao().GetJoin();
        }

        public AccountObject GetByUserId(Guid ID)
        {
            return new AccountDao().GetByUserId(ID);
        }


        public bool Delete(Guid ID)
        {
            return new AccountDao().Delete(ID);
        }

        public AccountObject CheckLogin(AccountObject obj)
        {
            return new AccountDao().CheckLogin(obj);
        }
    }
}
