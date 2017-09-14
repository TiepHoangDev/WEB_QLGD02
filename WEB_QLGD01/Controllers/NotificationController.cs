using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index(bool? status)
        {
            var accout = new WEB_QLGD01.Models.Login().GetAccount();
            if (status == null)
            {
                status = false;
            }
            if (status == false)
            {
                ViewBag.Status = false;
                return View(new NotificationsBCL().GetByUserID2(accout.UserId).Where(x => x.status == false).OrderByDescending(x => x.StartDate));
            }
            else
            {
                ViewBag.Status = true;
                return View(new NotificationsBCL().GetByUserID2(accout.UserId).Where(x => x.status == true).OrderByDescending(x => x.StartDate));
            }
                    
        }
        public ActionResult Detail(Guid id , int IsOption=0)
        {
            GetComboboxCompany();
            ViewBag.IsOption = IsOption;
            var data = new NotificationsBCL().GetByID(id);
            return View(data);
        }
        public ActionResult _Notificaton()
        {
            var accout = new WEB_QLGD01.Models.Login().GetAccount();          
            return PartialView(new NotificationsBCL().GetByUserID2(accout.UserId).Where(x=>x.status == false).OrderByDescending(x=>x.StartDate));
        }
        public void GetComboboxCompany()
        {
            ViewBag.UserId = new SelectList(new AccountBCL().GetAll(), "UserId", "FullName");
            ViewBag.UserId2 = new SelectList(new AccountBCL().GetAll(), "UserId", "FullName");
        }
        [HttpPost]
        public JsonResult deleteNotification(Guid IdNotification)
        {
            var data = new NotificationsBCL().GetByID(IdNotification);
            if (data != null)
            {
                data.status = true;
                new NotificationsBCL().UPDATE(data);
                return Json(data);
            }
            else
            {
                return Json("loi");
            }
        }
    }
}