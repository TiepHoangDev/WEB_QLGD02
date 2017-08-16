using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class CoursesBCL
    {

        public bool Insert(CoursesObjects ob)
        {
            return new CoursesDao().Insert(ob);
        }


        public bool Update(CoursesObjects ob)
        {
            return new CoursesDao().Update(ob);
        }


        public List<CoursesObjects> GetAll()
        {
            return new CoursesDao().GetAll();
        }


        public CoursesObjects GetByCoId(Guid ID)
        {
            return new CoursesDao().GetByCoId(ID);
        }


        public bool Delete(Guid ID)
        {
            return new CoursesDao().Delete(ID);
        }


    }
}
