using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BussinessObject.Objects;
using DataAccessLayer.Dao;

namespace WCF.BussinessController.BCL
{
    public class EmailBCL
    {
        public EmailObject GetEmail()
        {
            return new EmailDao().GetEmail();
        }
    }
}
