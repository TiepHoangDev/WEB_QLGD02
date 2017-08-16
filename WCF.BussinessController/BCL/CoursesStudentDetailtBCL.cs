using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class CoursesStudentDetailtBCL
    {

        public bool Insert(CoursesStudentDetailtObject ob)
        {
            return new CoursesStudentDetailtDao().Insert(ob);
        }


        public bool Update(CoursesStudentDetailtObject ob)
        {
            return new CoursesStudentDetailtDao().Update(ob);
        }


        public List<CoursesStudentDetailtObject> GetAll()
        {
            return new CoursesStudentDetailtDao().GetAll();
        }


        public CoursesStudentDetailtObject GetByScsId(Guid ID)
        {
            return new CoursesStudentDetailtDao().GetByScsId(ID);
        }

        public CoursesStudentDetailtObject GetByCJId(Guid ID)
        {
            return new CoursesStudentDetailtDao().GetByCJId(ID);
        }

        public CoursesStudentDetailtObject GetByStudetId(Guid ID)
        {
            return new CoursesStudentDetailtDao().GetByStudetId(ID);
        }

        public bool Delete(Guid ID)
        {
            return new CoursesStudentDetailtDao().Delete(ID);
        }

        public List<CoursesStudentDetailtObject> GetJoin()
        {
            return new CoursesStudentDetailtDao().GetJoin();
        }
    }
}
