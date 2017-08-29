﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Weekday
        public ActionResult Index()
        {
            return View(new CoursesBCL().GetAll().Where(x => x.Status == false));
        }
        // GET: Weekday/Create]
        public ActionResult anlyzeUser_byTime(DateTime? start, DateTime? end, bool? Status)
        {
            if (start == null || end == null)
            {
                if (Status == false)
                {
                    ViewBag.test = false;
                    var data = new CoursesBCL().GetAll().Where(x => x.Status == false).ToList();
                    return View("Index", data);
                }
                else
                {
                    ViewBag.test = true;
                    return View("Index", new CoursesBCL().GetAll().Where(x => x.Status == true));
                }
            }
            else
            {
                if (Status == false)
                {
                    return View("Index", new CoursesBCL().GetAll().Where(x => x.Status == false && x.StartDate >= start && x.EndDate <= end));
                }
                else
                {
                    ViewBag.test = true;
                    return View("Index", new CoursesBCL().GetAll().Where(x => x.Status == true && x.StartDate >= start && x.EndDate <= end));
                }
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Weekday/Create
        [HttpPost]
        public ActionResult Create(CoursesObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ob != null)
                {
                    ob.CoId = Guid.NewGuid();
                    ob.Deleted = false;
                    ob.Status = false;
                    if (new CoursesBCL().Insert(ob))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
            }
            return View();
        }

        // GET: Weekday/Edit/5
        public ActionResult Edit(Guid ID)
        {
            return View(new CoursesBCL().GetByCoId(ID));
        }

        // POST: Weekday/Edit/5
        [HttpPost]
        public ActionResult Edit(CoursesObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ob.Deleted = false;
                if (ob != null && new CoursesBCL().Update(ob))
                    return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();
        }


        // POST: Weekday/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
            return Json(new CoursesBCL().Delete(ID));
        }
    }
}
