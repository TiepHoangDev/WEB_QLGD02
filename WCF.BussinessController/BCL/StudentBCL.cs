using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class StudentBCL
    {

        public bool Insert(StudentObjects ob)
        {
            return new StudentDao().Insert(ob);
        }


        public bool Update(StudentObjects ob)
        {
            return new StudentDao().Update(ob);
        }


        public List<StudentObjects> GetAll()
        {
            return new StudentDao().GetAll();
        }


        public StudentObjects GetByStudetId(Guid ID)
        {
            return new StudentDao().GetByStudetId(ID);
        }


        public bool Delete(Guid ID)
        {
            return new StudentDao().Delete(ID);
        }


    }
}
