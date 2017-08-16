using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF.BussinessObject.Objects
{
   public class SP_GetAll_StudentDetailtObjects
    {
        public System.Guid StdId { get; set; }
        public string FullName { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

    }
}
