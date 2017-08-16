
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class StudentDetailtDao
    {

        public bool Insert(StudentDetailtObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_StudentDetailt_INSERT(ob.StdId, ob.StudetId, ob.CoId, ob.Description);
            return true;
        }


        public bool Update(StudentDetailtObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_StudentDetailt_UPDATE(ob.StdId, ob.StudetId, ob.CoId, ob.Description);
            return true;
        }


        public List<StudentDetailtObjects> GetAll()
        {
            var lit = new eTrainingScheduleEntities().sp_tbl_S07_StudentDetailt_GetAll();
            List<StudentDetailtObjects> lst = new List<StudentDetailtObjects>();

            foreach (var item in lit)
            {
                StudentDetailtObjects obj = new StudentDetailtObjects();
                obj.StdId = item.StdId;
                obj.CoId = item.CoId;
                obj.Description = item.Description;
                obj.StudetId = item.StudetId;
                lst.Add(obj);
            }
            return lst;
        }

        public List<StudentDetailtObjects> GetJoin()
        {
            List<StudentDetailtObjects> lst = new List<StudentDetailtObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_StudentDetailt_Join();
            foreach (var item in list)
            {
                if (item.DeletedStudent == true || item.DeletedCourses == true) continue;

                StudentDetailtObjects ob = new StudentDetailtObjects();
                ob.StdId = item.StdId;
                ob.StudetId = item.StudetId;
                ob.CoId = item.CoId;
                ob.Description = item.DescriptionStudent;
                ob.CoursesJoin = new CoursesObjects()
                {
                    CoId = (Guid)item.CoId,
                    CourseId = item.CourseId,
                    CourseName = item.CourseName,
                    Deleted = item.DeletedCourses,
                    Description = item.DescriptionCourses,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    Status = item.StatusCourses,
                    TotalNumber = item.TotalNumber
                };
                ob.StudentJoin = new StudentObjects()
                {
                    Address = item.Address,
                    Deleted = item.DeletedStudent,
                    Email = item.Email,
                    FullName = item.FullName,
                    Mobile = item.Mobile,
                    Status = item.StatusStudent,
                    StudetId = (Guid)item.StudetId
                };
                lst.Add(ob);
            }
            return lst;
        }

        public StudentDetailtObjects GetByStdId(StudentDetailtObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_StudentDetailt_GetByStdId(ob.StdId);
            foreach (var item in list)
            {
                StudentDetailtObjects obj = new StudentDetailtObjects();
                obj.StdId = item.StdId; obj.StudetId = item.StudetId; obj.CoId = item.CoId; obj.Description = item.Description;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid id)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_StudentDetailt_DELETE(id);
            return true;
        }
    }
}
