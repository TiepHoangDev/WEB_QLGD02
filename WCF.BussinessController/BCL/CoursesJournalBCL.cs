using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class CoursesJournalBCL
    {

        public bool Insert(CoursesJournalObjects ob)
        {
            return new CoursesJournalDao().Insert(ob);
        }


        public bool Update(CoursesJournalObjects ob)
        {
            return new CoursesJournalDao().Update(ob);
        }


        public List<CoursesJournalObjects> GetAll()
        {
            return new CoursesJournalDao().GetAll();
        }


        public CoursesJournalObjects GetByCJId(Guid ID)
        {
            return new CoursesJournalDao().GetByCJId(ID);
        }


        public bool Delete(Guid ID)
        {
            return new CoursesJournalDao().Delete(ID);
        }

        public List<CoursesJournalObjects> GetJoin()
        {
            return new CoursesJournalDao().GetJoin();
        }
    }
}
