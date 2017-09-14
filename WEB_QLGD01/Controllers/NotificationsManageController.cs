using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;
using WEB_QLGD01.App_Start;
namespace WEB_QLGD01.Controllers
{
    public class NotificationsManageController : Controller
    {
        // GET: Notifications
        public ActionResult Index(bool? Status)
        {
            if (Status == null)
            {
                Status = false;
            }
            if (Status == false)
            {
                ViewBag.Status = false;
                var list = new NotificationsBCL().GetAll().Where(x => x.status == false);
                return View(list);
            }
            else
            {
                ViewBag.Status = true;
                var list = new NotificationsBCL().GetAll().Where(x => x.status == true);
                return View(list);
            }
        }

        // GET: Notifications/Details/5
        public ActionResult Details(Guid id,int IsOption = 0)
        {
            GetComboboxCompany();

            ViewBag.IsOption = IsOption;

            var data = new NotificationsBCL().GetByID(id);
            return View(data);
        }
        public enum Ordernumber
        {
            SuperAmin = 0,
            Admin = 1,
            Moderator = 2,
            Member = 3
        }
       
        // GET: Notifications/Create
        public ActionResult Create(int IsOption=0)
        {
            GetComboboxCompany();
            ViewBag.IsOption = IsOption;
            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        public ActionResult Create(NotificationsObjects obj, int IsOption)
        {
            obj.notificationsID = Guid.NewGuid();
            obj.StartDate = DateTime.Now;
            obj.Isdeleted = false;
            obj.status = false;
            var accout = new Models.Login().GetAccount();

            obj.UserId = accout.UserId;
            string title = "Thông báo";
            string content = obj.Content;
            AccountObject obj1 = new AccountBCL().GetByUserId(obj.UserId2.GetValueOrDefault());
            string email = obj1.Email;
            //string email = "tran.trung.hieu.20061178@gmail.com";
            string bcc = "doanitsoft@gmail.com,tuvan@imicrosoft.edu.vn,phongdaotao@imicrosoft.edu.vn";
            new SMTPHelper().sendMail(content, email, bcc, title);

            var b = new NotificationsBCL().INSERT(obj);
            if (b)
            {
                if (IsOption == 0)
                {
                    return RedirectToAction("Index", "NotificationsManage");
                }
                else
                {
                    return RedirectToAction("NotificationIndex", "NotificationsManage");
                }
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }
        //Them moi truc tiep ngoai main
        public ActionResult Create_main()
        {
            GetComboboxCompany();

            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        public ActionResult Create_main(NotificationsObjects obj)
        {
            obj.notificationsID = Guid.NewGuid();
            obj.StartDate = DateTime.Now;
            obj.Isdeleted = false;
            obj.status = false;
            var accout = new Models.Login().GetAccount();

            obj.UserId = accout.UserId;
            string title = "Thông báo";
            string content = obj.Content;
            AccountObject obj1 = new AccountBCL().GetByUserId(obj.UserId2.GetValueOrDefault());
            string email = obj1.Email;
            //string email = "tran.trung.hieu.20061178@gmail.com";
            string bcc = "doanitsoft@gmail.com,tuvan@imicrosoft.edu.vn,phongdaotao@imicrosoft.edu.vn";
            new SMTPHelper().sendMail(content, email, bcc, title);

            var b = new NotificationsBCL().INSERT(obj);
            if (b)
            {
                return RedirectToAction("NotificationIndex", "NotificationsManage");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }

        // GET: Notifications/Edit/5
        public ActionResult Edit(Guid id)
        {

            return View();
        }

        // POST: Notifications/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            return View();
        }

        // GET: Notifications/Delete/5


        // POST: Notifications/Delete/5
        [HttpPost]
        public JsonResult Delete(Guid ID)
        {

            return Json(new NotificationsBCL().DELETE(ID));
        }
        Ordernumber GetOderNumber(Guid AccountID)
        {
            AccountObject objAccout = new AccountBCL().GetByUserId(AccountID);
            var objrole = new RoleBCL().GetByRoleId((Guid)objAccout.RoleId);
            switch (objrole.RName)
            {
                case "SuperAdmin":
                    return Ordernumber.SuperAmin;
                case "Admin":
                    return Ordernumber.Admin;
                case "TuVanVien":
                    return Ordernumber.Moderator;
                default:
                    return Ordernumber.Member;
            }
        }
        Ordernumber GetOderNumberRole(Guid? RoldID)
        {
            var objrole = new RoleBCL().GetByRoleId((Guid)RoldID);
            switch (objrole.RName)
            {
                case "SuperAdmin":
                    return Ordernumber.SuperAmin;
                case "Admin":
                    return Ordernumber.Admin;
                case "TuVanVien":
                    return Ordernumber.Moderator;
                default:
                    return Ordernumber.Member;
            }
        }
        public void GetComboboxCompany()
        {
            var accout = new Models.Login().GetAccount();
            var RoleOfUser = GetOderNumber(accout.UserId);
            ViewBag.UserId = new SelectList(new AccountBCL().GetAll().Where(x =>GetOderNumberRole(x.RoleId) > RoleOfUser), "UserId", "FullName");
            ViewBag.UserId2 = new SelectList(new AccountBCL().GetAll().Where(x => GetOderNumberRole(x.RoleId) > RoleOfUser), "UserId", "FullName");
        }
        #region Notication Messge layot
        //indexmessage
        public ActionResult _NotificatonMessage()
        { 
            var accout = new WEB_QLGD01.Models.Login().GetAccount();
            return PartialView(new NotificationsBCL().GetByUserID(accout.UserId).Where(x => x.status == false).OrderByDescending(x => x.StartDate));
        }

        public ActionResult NotificationIndex(bool? status)
        {
            var accout = new WEB_QLGD01.Models.Login().GetAccount();
            if (status == null)
            {
                status = false;
            }
            if (status == false)
            {
                ViewBag.Status = false;
                return View(new NotificationsBCL().GetByUserID(accout.UserId).Where(x => x.status == false).OrderByDescending(x => x.StartDate));
            }
            else
            {
                ViewBag.Status = true;
                return View(new NotificationsBCL().GetByUserID(accout.UserId).Where(x => x.status == true).OrderByDescending(x => x.StartDate));
            }
        }
        #endregion
    }
}
