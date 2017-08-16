using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class ExpertsDetailtBCL
    {

        public bool Insert(ExpertsDetailtObjects ob)
        {
            return new ExpertsDetailtDao().Insert(ob);
        }


        public bool Update(ExpertsDetailtObjects ob)
        {
            return new ExpertsDetailtDao().Update(ob);
        }


        public List<ExpertsDetailtObjects> GetAll()
        {
            return new ExpertsDetailtDao().GetAll();
        }


        public ExpertsDetailtObjects GetByExId(Guid ExId)
        {
            return new ExpertsDetailtDao().GetByExId(ExId);
        }

        public List<ExpertsDetailtObjects> GetByCoId(Guid CoId)
        {
            return new ExpertsDetailtDao().GetByCoId(CoId);
        }


        public bool Delete(Guid ID)
        {
            return new ExpertsDetailtDao().Delete(ID);
        }

        public List<ExpertsDetailtObjects> GetJoin()
        {
            return new ExpertsDetailtDao().GetJoin();
        }
    }
}
