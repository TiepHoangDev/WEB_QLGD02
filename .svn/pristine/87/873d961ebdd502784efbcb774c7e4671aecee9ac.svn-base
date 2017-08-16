using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class CoursesStudentDetailtDao
    {

        public bool Insert(CoursesStudentDetailtObject ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesStudentDetailt_INSERT(ob.ScsId, ob.StudetId, ob.CJId, ob.Description);
            return true;
        }


        public bool Update(CoursesStudentDetailtObject ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesStudentDetailt_Update(ob.ScsId, ob.StudetId, ob.CJId, ob.Description);
            return true;
        }


        public List<CoursesStudentDetailtObject> GetAll()
        {
            List<CoursesStudentDetailtObject> lst = new List<CoursesStudentDetailtObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_CoursesStudentDetailt_GetAll();
            foreach (var item in list)
            {
                CoursesStudentDetailtObject ob = new CoursesStudentDetailtObject();
                ob.ScsId = item.ScsId;
                ob.Description = item.Description;
                ob.CJId = item.CJId;
                ob.StudetId = item.StudetId;
                lst.Add(ob);
            }
            return lst;
        }

        public List<CoursesStudentDetailtObject> GetJoin()
        {
            List<CoursesStudentDetailtObject> lst = new List<CoursesStudentDetailtObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.CoursesStudentDetail_Join();
            foreach (var item in list)
            {
                CoursesStudentDetailtObject ob = new CoursesStudentDetailtObject();
                ob.ScsId = item.ScsId; ob.StudetId = item.StudetId; ob.CJId = item.CJId; ob.Description = item.Description_CoursesStudentDetailt;
                ob.CoursesJournalJoin = new CoursesJournalObjects()
                {
                    CoId = item.CoId,
                    CJId = item.CJId,
                    Contents = item.Contents,
                    DayOf = item.DayOf,
                    Description = item.Description_CoursesJournal
                };
                ob.StudentJoin = new StudentObjects()
                {
                    Address = item.Address,
                    Deleted = item.Deleted,
                    Email = item.Email,
                    FullName = item.FullName,
                    Mobile = item.Mobile,
                    Status = item.Status,
                    StudetId = (Guid)item.StudetId
                };
                lst.Add(ob);
            }
            return lst;
        }

        public CoursesStudentDetailtObject GetByScsId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_CoursesStudentDetailt_GetByScsId(ID);
            foreach (var item in list)
            {
                CoursesStudentDetailtObject obj = new CoursesStudentDetailtObject();
                obj.ScsId = item.ScsId; obj.StudetId = item.StudetId; obj.CJId = item.CJId; obj.Description = item.Description;
                return obj;
            }
            return null;
        }

        public CoursesStudentDetailtObject GetByCJId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_CoursesStudentDetailt_GetByCJId(ID);
            CoursesStudentDetailtObject obj = new CoursesStudentDetailtObject();
            foreach (var item in list)
            {
                obj.ScsId = item.ScsId; obj.StudetId = item.StudetId; obj.CJId = item.CJId; obj.Description = item.Description;
            }
            return obj;
        }

        public CoursesStudentDetailtObject GetByStudetId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_CoursesStudentDetailt_GetByStudetId(ID);
            CoursesStudentDetailtObject obj = new CoursesStudentDetailtObject();
            foreach (var item in list)
            {
                obj.ScsId = item.ScsId; obj.StudetId = item.StudetId; obj.CJId = item.CJId; obj.Description = item.Description;
            }
            return obj;
        }
        public bool Delete(Guid id)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_CoursesStudentDetailt_Delete(id);
            return true;

        }
    }
}
