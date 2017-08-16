using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class CoursesJournalDao
    {

        public bool Insert(CoursesJournalObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesJournal_INSERT(ob.CJId, ob.CoId, ob.DayOf, ob.Contents, ob.Description);
            return true;
        }


        public bool Update(CoursesJournalObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesJournal_UPDATE(ob.CJId, ob.CoId, ob.DayOf, ob.Contents, ob.Description);
            return true;
        }


        public List<CoursesJournalObjects> GetAll()
        {
            List<CoursesJournalObjects> lst = new List<CoursesJournalObjects>();
            var db = new eTrainingScheduleEntities().sp_tbl_S07_CoursesJournal_GetAll();

            foreach (var item in db)
            {
                CoursesJournalObjects ob = new CoursesJournalObjects();
                ob.CJId = item.CJId;
                ob.Contents = item.Contents;
                ob.DayOf = item.DayOf;
                ob.Description = item.Description;
                ob.CoId = item.CoId;
                lst.Add(ob);
            }
            return lst;
        }

        public CoursesJournalObjects GetByCJId(Guid ob)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_CoursesJournal_GetByCJId(ob);
            foreach (var item in list)
            {
                CoursesJournalObjects obj = new CoursesJournalObjects();
                obj.CJId = item.CJId; obj.CoId = item.CoId; obj.DayOf = item.DayOf; obj.Contents = item.Contents; obj.Description = item.Description;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesJournal_DELETE(ID);
            return true;
        }

        public List<CoursesJournalObjects> GetJoin()
        {
            List<CoursesJournalObjects> lst = new List<CoursesJournalObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_CoursesJournal_Join();
            foreach (var item in list)
            {
                CoursesJournalObjects ob = new CoursesJournalObjects();
                ob.CJId = item.CJId; ob.CoId = item.CoId; ob.DayOf = item.DayOf; ob.Contents = item.Contents; ob.Description = item.DescriptionCoursesJournal;
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
                lst.Add(ob);
            }
            return lst;
        }

    }
}
