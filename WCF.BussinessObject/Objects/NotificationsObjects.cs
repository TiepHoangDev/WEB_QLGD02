using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BussinessObject.Objects
{
   public class NotificationsObjects
    {
        public System.Guid notificationsID { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public string title { get; set; }
        public string Content { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<System.Guid> UserId2 { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
        public AccountObject Account1 { get; set; }
        public AccountObject Account2 { get; set; }
    }
}
