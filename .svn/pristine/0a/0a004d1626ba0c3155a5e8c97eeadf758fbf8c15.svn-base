
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class StudentDao
    {

        public bool Insert(StudentObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Student_INSERT(ob.StudetId, ob.FullName, ob.Email, ob.Mobile, ob.Address, ob.Status, ob.Deleted);
            return true;
        }


        public bool Update(StudentObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Student_UPDATE(ob.StudetId, ob.FullName, ob.Email, ob.Mobile, ob.Address, ob.Status, ob.Deleted);
            return true;
        }


        public List<StudentObjects> GetAll()
        {
            List<StudentObjects> lst = new List<StudentObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Student_GetAll();
            foreach (var item in list)
            {
                if (item.Deleted == true) continue;
                StudentObjects ob = new StudentObjects();
                ob.StudetId = item.StudetId; ob.FullName = item.FullName; ob.Email = item.Email; ob.Mobile = item.Mobile; ob.Address = item.Address; ob.Status = item.Status; ob.Deleted = item.Deleted;
                lst.Add(ob);
            }
            return lst;
        }


        public StudentObjects GetByStudetId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Student_GetByStudetId(ID);
            foreach (var item in list)
            {
                StudentObjects obj = new StudentObjects();
                obj.StudetId = item.StudetId; obj.FullName = item.FullName; obj.Email = item.Email; obj.Mobile = item.Mobile; obj.Address = item.Address; obj.Status = item.Status; obj.Deleted = item.Deleted;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var ob = GetByStudetId(ID);
            if (ob == null) return false;
            ob.Deleted = true;
            Update(ob);
            return true;
        }
    }
}
