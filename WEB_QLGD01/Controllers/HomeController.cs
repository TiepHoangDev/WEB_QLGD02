﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Value = "All";
            return View(new SchedulersBCL().GetJoin());
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            try
            {
                Guid ID_Expert = Guid.Parse(f["GV"]);
                ViewBag.Value = ID_Expert.ToString();
                return View(GetScheduler(ID_Expert));
            }
            catch
            {
                ViewBag.Value = "All";
                return View(new SchedulersBCL().GetJoin());
            }
        }

        public List<SchedulersObjects> GetScheduler(Guid ID_Expert)
        {
            List<SchedulersObjects> lst = new List<SchedulersObjects>();
            var listExpertDetail = new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertId == ID_Expert).ToList();
            var listSchedeler = new SchedulersBCL().GetJoin();
            foreach (var expd in listExpertDetail)
            {
                lst.AddRange(listSchedeler.Where(q => q.CoId == expd.CoursesJoin.CoId));
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SchedulersObjects ob)
        {
            if (ob != null)
            {
                ob.ScId = Guid.NewGuid();
                if (new SchedulersBCL().Insert(ob))
                {
                    return RedirectToAction("Index");
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