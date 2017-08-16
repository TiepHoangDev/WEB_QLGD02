using WCF.BussinessObject.Objects;
using System;
using System.Collections.Generic;
using DataAccessLayer.DataModels;
namespace DataAccessLayer.Dao
{
    public class FeaIdDao
    {

        public bool Insert(FeaIdObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_FeaId_INSERT(ob.FeaId, ob.FeaName, ob.Isdeleted) > 0;
        }


        public bool Update(FeaIdObject ob)
        {
            var db = new eTrainingScheduleEntities();
            return db.sp_tbl_FeaId_UPDATE(ob.FeaId, ob.FeaName, ob.Isdeleted) > 0;
        }


        public List<FeaIdObject> GetAll()
        {
            List<FeaIdObject> lst = new List<FeaIdObject>();
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_FeaId_GetAll();
            foreach (var item in list)
            {
                if (item.Isdeleted == true)
                    continue;
                FeaIdObject ob = new FeaIdObject();
                ob.FeaId = item.FeaId; ob.FeaName = item.FeaName; ob.Isdeleted = item.Isdeleted;
                lst.Add(ob);
            }
            return lst;
        }


        public FeaIdObject GetByFeaId(string ID)
        {
            var db = new eTrainingScheduleEntities();
            var list = db.sp_tbl_FeaId_GetByFeaId(ID);
            foreach (var item in list)
            {
                FeaIdObject obj = new FeaIdObject();
                obj.FeaId = item.FeaId; obj.FeaName = item.FeaName; obj.Isdeleted = item.Isdeleted;
                return obj;
            }
            return null;
        }


        public bool Delete(string ID)
        {
            var db = new eTrainingScheduleEntities();
            var obj = GetByFeaId(ID);
            if (obj == null) return false;
            obj.Isdeleted = true;
            return Update(obj);
        }


    }
}
