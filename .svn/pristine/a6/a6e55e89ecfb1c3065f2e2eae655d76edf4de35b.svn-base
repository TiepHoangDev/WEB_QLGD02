
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class WeekdaysDao
    {

        public bool Insert(WeekdaysObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Weekdays_INSERT(ob.WeId, ob.WeName, ob.Description);
            return true;
        }


        public bool Update(WeekdaysObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Weekdays_UPDATE(ob.WeId, ob.WeName, ob.Description);
            return true;
        }


        public List<WeekdaysObjects> GetAll()
        {
            List<WeekdaysObjects> lst = new List<WeekdaysObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Weekdays_GetAll();
            foreach (var item in list)
            {
                WeekdaysObjects ob = new WeekdaysObjects();
                ob.WeId = item.WeId; ob.WeName = item.WeName; ob.Description = item.Description;
                lst.Add(ob);
            }
            return lst;
        }


        public WeekdaysObjects GetByWeId(WeekdaysObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Weekdays_GetByWeId(ob.WeId);
            foreach (var item in list)
            {
                WeekdaysObjects obj = new WeekdaysObjects();
                obj.WeId = item.WeId; obj.WeName = item.WeName; obj.Description = item.Description;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Weekdays_DELETE(ID);
            return true;
        }


    }
}
