﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;
using WEB_QLGD01.Models;

namespace WEB_QLGD01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Guid? ID_Expert = null)
        {
            var user = new Models.Login().GetAccount();
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            if (user.RoleId.Equals(new Guid("ADAE8847-5B4D-43FC-A761-038B315D7651")))
            {
                ViewBag.Role = user.RoleId;
                return View(GetScheduler(user.UserId));
            }
            if (ID_Expert.HasValue)
            {


                ViewBag.Value = ID_Expert;

                return View(GetScheduler(ID_Expert.Value));
            }
            ViewBag.Value = null;
            ViewBag.Role = null;
            return View(new SchedulersBCL().GetJoin().Where(q => q.CoursesJoin.Status == false).ToList());
        }


        public List<SchedulersObjects> GetScheduler(Guid ID_Expert)
        {
            List<SchedulersObjects> lst = new List<SchedulersObjects>();
            var listExpertDetail = new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertId == ID_Expert);
            var listSchedeler = new SchedulersBCL().GetJoin();
            foreach (var expd in listExpertDetail)
            {
                lst.AddRange(listSchedeler.Where(q => q.CoursesJoin.Status == false && q.CoId == expd.CoursesJoin.CoId));
            }
            return lst;
        }

        [HttpPost]
        public ActionResult GetData(string n, string v)
        {
            object result = null;
            Guid ID = Guid.Parse(v);
            switch (n)
            {
                case "MaLop":
                case "KhoaHoc":
                    var c = new CoursesBCL().GetByCoId(ID);
                    result = new { c.CoId, c.CourseId, c.CourseName, c.StartDate, c.EndDate, c.TotalNumber, c.Status, c.Description };
                    break;
                case "GiaoVien":
                    result = (from g in new ExpertsDetailtBCL().GetByCoId(ID)
                              where g.CoursesJoin.Status == false
                              select new { g.ExpertsJoin.FullName, g.ExpertsJoin.Address, g.ExpertsJoin.Mobile, g.ExpertsJoin.Status }).ToList();
                    break;
                case "Delete":
                    result = new SchedulersBCL().Delete(ID);
                    break;
                default:
                    break;
            }
            return Json(result);
        }

        public ActionResult Create( )
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(SchedulersObjects ob)
        {
            if (ob != null)
            {
                ob.ScId = Guid.NewGuid();
                var allsc = new SchedulersBCL().GetJoin();
                bool oke = !allsc.Any(q => q.CoId == ob.CoId && q.WeId == ob.WeId && q.ShiftId == ob.ShiftId);
                if (!oke)
                {
                    ModelState.AddModelError("", "Một khóa học ko thể xuất hiện 2 lần trong 1 ca học");
                }
                else
                {
                    if (new SchedulersBCL().Insert(ob))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
            }
            return View();
        }

        public ActionResult Edit(Guid ID)
        {
            return View(new SchedulersBCL().GetByScId(ID));
        }

        [HttpPost]
        public ActionResult Edit(SchedulersObjects ob)
        {
            if (ob != null && new SchedulersBCL().Update(ob))
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}