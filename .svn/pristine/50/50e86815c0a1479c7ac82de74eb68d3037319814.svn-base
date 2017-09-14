using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BussinessObject.Objects;
using DataAccessLayer.DataModels;

namespace DataAccessLayer.Dao
{
    public class EmailDao
    {
        public EmailObject GetEmail()
        {
            eTrainingScheduleEntities db = new eTrainingScheduleEntities();
            foreach (var item in db.sp_SentEmail_GetAll())
            {
                EmailObject obj = new EmailObject();
                obj.ID = (Guid)item.ID;
                obj.Email = item.Email;
                obj.Password = item.Password;
                return obj;
            }
            return null;
        }
    }
}
