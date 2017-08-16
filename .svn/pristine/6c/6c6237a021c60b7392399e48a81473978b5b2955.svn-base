
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class SchedulersDao
    {

        public bool Insert(SchedulersObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Schedulers_INSERT(ob.ScId, ob.WeId, ob.ShiftId, ob.CoId, ob.Description);
            return true;
        }


        public bool Update(SchedulersObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Schedulers_UPDATE(ob.ScId, ob.WeId, ob.ShiftId, ob.CoId, ob.Description);
            return true;
        }


        public List<SchedulersObjects> GetAll()
        {
            List<SchedulersObjects> lst = new List<SchedulersObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Schedulers_GetAll();
            foreach (var item in list)
            {
                SchedulersObjects ob = new SchedulersObjects();
                ob.ScId = item.ScId;
                ob.Description = item.Description;
                ob.CoId = item.CoId;
                ob.ShiftId = item.ShiftId;
                ob.WeId = item.WeId;
                ob.WeId = item.WeId;
                lst.Add(ob);
            }
            return lst;
        }


        public List<SchedulersObjects> GetJoin()
        {
            List<SchedulersObjects> lst = new List<SchedulersObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_Schedulers_Join();
            foreach (var item in list)
            {
                SchedulersObjects ob = new SchedulersObjects();
                ob.ScId = item.ScId; ob.WeId = item.WeId; ob.ShiftId = item.ShiftId; ob.CoId = item.CoId; ob.Description = item.DescriptionSchedulers;
                ob.CoursesJoin = new CoursesObjects()
                {
                    CoId = (Guid)item.CoId,
                    CourseId = item.CourseId,
                    CourseName = item.CourseName,
                    Deleted = item.Deleted,
                    Description = item.DescriptionCourses,
                    EndDate = item.EndDate,
                    StartDate = item.StartDate,
                    Status = item.Status,
                    TotalNumber = item.TotalNumber
                };
                ob.ShiftDayJoin = new ShiftDayObjects()
                {
                    Description = item.DescriptionShift,
                    ShiftId = (Guid)item.ShiftId,
                    ShiftName = item.ShiftName
                };
                ob.WeekdaysJoin = new WeekdaysObjects()
                {
                    Description = item.DescriptionWeekday,
                    WeId = (Guid)item.WeId,
                    WeName = item.WeName
                };
                lst.Add(ob);
            }
            return lst;
        }

        public SchedulersObjects GetByScId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Schedulers_GetByScId(ID);
            foreach (var item in list)
            {
                SchedulersObjects obj = new SchedulersObjects();
                obj.ScId = item.ScId; obj.WeId = item.WeId; obj.ShiftId = item.ShiftId; obj.CoId = item.CoId; obj.Description = item.Description;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid id)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Schedulers_DELETE(id);
            return true;
        }


    }
}
