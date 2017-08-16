
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class ShiftDayDao
    {

        public bool Insert(ShiftDayObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_ShiftDay_INSERT(ob.ShiftId, ob.ShiftName, ob.Description);
            return true;
        }


        public bool Update(ShiftDayObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_ShiftDay_UPDATE(ob.ShiftId, ob.ShiftName, ob.Description);
            return true;
        }


        public List<ShiftDayObjects> GetAll()
        {
            List<ShiftDayObjects> lst = new List<ShiftDayObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_ShiftDay_GetAll();
            foreach (var item in list)
            {
                ShiftDayObjects ob = new ShiftDayObjects();
                ob.ShiftId = item.ShiftId; ob.ShiftName = item.ShiftName; ob.Description = item.Description;
                lst.Add(ob);
            }
            return lst;
        }


        public ShiftDayObjects GetByShiftId(Guid ob)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_ShiftDay_GetByShiftId(ob);
            foreach (var item in list)
            {
                ShiftDayObjects obj = new ShiftDayObjects();
                obj.ShiftId = item.ShiftId; obj.ShiftName = item.ShiftName; obj.Description = item.Description;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_ShiftDay_DELETE(ID);
            return true;
        }

    }
}
