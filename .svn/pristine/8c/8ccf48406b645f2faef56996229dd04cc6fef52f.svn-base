using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;
using System;
using System.Collections.Generic;
namespace WCF.BussinessController.BCL
{
    public class StudentDetailtBCL
    {

        public bool Insert(StudentDetailtObjects ob)
        {
            return new StudentDetailtDao().Insert(ob);
        }


        public bool Update(StudentDetailtObjects ob)
        {
            return new StudentDetailtDao().Update(ob);
        }


        public List<StudentDetailtObjects> GetAll()
        {
            return new StudentDetailtDao().GetAll();
        }

        public List<StudentDetailtObjects> GetJoin()
        {
            return new StudentDetailtDao().GetJoin();
        }

        public StudentDetailtObjects GetByStdId(StudentDetailtObjects ob)
        {
            return new StudentDetailtDao().GetByStdId(ob);
        }


        public bool Delete(Guid ID)
        {
            return new StudentDetailtDao().Delete(ID);
        }


    }
}
