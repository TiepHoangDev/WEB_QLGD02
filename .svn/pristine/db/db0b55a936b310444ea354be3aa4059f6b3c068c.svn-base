
using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class ExpertsDao
    {

        public bool Insert(ExpertsObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Experts_INSERT(ob.ExpertId, ob.FullName, ob.Email, ob.Mobile, ob.Address, ob.Specialize, ob.StartDate, ob.Status, ob.Description, ob.Deleted);
            return true;
        }


        public bool Update(ExpertsObjects ob)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Experts_UPDATE(ob.ExpertId, ob.FullName, ob.Email, ob.Mobile, ob.Address, ob.Specialize, ob.StartDate, ob.Status, ob.Description, ob.Deleted);
            return true;
        }


        public List<ExpertsObjects> GetAll()
        {
            List<ExpertsObjects> lst = new List<ExpertsObjects>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Experts_GetAll();
            foreach (var item in list)
            {
                if (item.Deleted == true) continue;
                ExpertsObjects ob = new ExpertsObjects();
                ob.ExpertId = item.ExpertId; ob.FullName = item.FullName; ob.Email = item.Email; ob.Mobile = item.Mobile; ob.Address = item.Address; ob.Specialize = item.Specialize; ob.StartDate = item.StartDate; ob.Status = item.Status; ob.Description = item.Description; ob.Deleted = item.Deleted;
                lst.Add(ob);
            }
            return lst;
        }


        public ExpertsObjects GetByExpertId(Guid ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_S07_Experts_GetByExpertId(ID);
            foreach (var item in list)
            {
                ExpertsObjects obj = new ExpertsObjects();
                obj.ExpertId = item.ExpertId; obj.FullName = item.FullName; obj.Email = item.Email; obj.Mobile = item.Mobile; obj.Address = item.Address; obj.Specialize = item.Specialize; obj.StartDate = item.StartDate; obj.Status = item.Status; obj.Description = item.Description; obj.Deleted = item.Deleted;
                return obj;
            }
            return null;
        }


        public bool Delete(Guid id)
        {
            var db = new eTrainingScheduleEntities();
            var data = db.sp_tbl_S07_Experts_DELETE(id);
            return true;
        }
    }
}
