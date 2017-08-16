using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class PermisstionBCL
    {

        public bool Insert(PermisstionObject ob)
        {
            return new PermisstionDao().Insert(ob);
        }


        public bool Update(PermisstionObject ob)
        {
            return new PermisstionDao().Update(ob);
        }


        public List<PermisstionObject> GetAll()
        {
            return new PermisstionDao().GetAll();
        }
        
        public PermisstionObject GetByPerID(Guid ID)
        {
            return new PermisstionDao().GetByPerID(ID);
        }


        public bool Delete(Guid ID)
        {
            return new PermisstionDao().Delete(ID);
        }



        public List<PermisstionObject> GetJoin()
        {
            return new PermisstionDao().GetJoin();
        }
    }
}
