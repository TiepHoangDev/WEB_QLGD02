using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.BussinessObject.Objects;
using WCF.BussinessController.BCL;

namespace WEB_QLGD01.Models
{
    public class Weekday
    {
        public List<WeekdaysObjects> GetAll()
        {
            return new WeekdaysBCL().GetAll().OrderBy(q => GetDay(q.WeName)).ToList();
        }

        private int GetDay(string p)
        {
            if (p.ToLower().Contains("hai")) return 0;
            else if (p.ToLower().Contains("ba")) return 1;
            else if (p.ToLower().Contains("tư")) return 2;
            else if (p.ToLower().Contains("năm")) return 3;
            else if (p.ToLower().Contains("sáu")) return 4;
            else if (p.ToLower().Contains("bảy")) return 5;
            else if (p.ToLower().Contains("nhật")) return 6;
            return 7;
        }
    }
}