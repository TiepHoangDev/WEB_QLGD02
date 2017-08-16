using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class CoursesDao
    {
        public bool Insert(CoursesObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Courses_INSERT(ob.CoId, ob.CourseId, ob.CourseName, ob.TotalNumber, ob.StartDate, ob.EndDate, ob.Status, ob.Description, ob.Deleted);
            return true;
        }


        public bool Update(CoursesObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Courses_UPDATE(ob.CoId, ob.CourseId, ob.CourseName, ob.TotalNumber, ob.StartDate, ob.EndDate, ob.Status, ob.Description, ob.Deleted);
            return true;
        }


        public List<CoursesObjects> GetAll()
        {
            List<CoursesObjects> lst = new List<CoursesObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Courses_GetAll();
            foreach (var item in list)
            {
                if (item.Deleted == true) continue;
                CoursesObjects ob = new CoursesObjects();
                ob.CoId = item.CoId; ob.CourseId = item.CourseId; ob.CourseName = item.CourseName; ob.TotalNumber = item.TotalNumber; ob.StartDate = item.StartDate; ob.EndDate = item.EndDate; ob.Status = item.Status; ob.Description = item.Description; ob.Deleted = item.Deleted;
                lst.Add(ob);
            }
            return lst;
        }


        public CoursesObjects GetByCoId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Courses_GetByCoId(ID);
            foreach (var item in list)
            {
                CoursesObjects obj = new CoursesObjects();
                obj.CoId = item.CoId; obj.CourseId = item.CourseId; obj.CourseName = item.CourseName; obj.TotalNumber = item.TotalNumber; obj.StartDate = item.StartDate; obj.EndDate = item.EndDate; obj.Status = item.Status; obj.Description = item.Description; obj.Deleted = item.Deleted;
                return obj;
            }
            return null;
        }

        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var ob = GetByCoId(ID);
            if (ob == null) return false;
            ob.Deleted = true;
            return Update(ob);

        }
    }
}
