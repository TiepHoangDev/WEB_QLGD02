﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class ExpertsDetailtController : Controller
    {
        // GET: ExpertsDetailt
        public ActionResult Index()
        {
            return View(new ExpertsDetailtBCL().GetJoin());
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var result = new List<ExpertsDetailtObjects>();
            Guid ID_Expert = new Guid();
            Guid ID_Course = new Guid();
            if (Guid.TryParse(f["Course"].ToString(), out ID_Course))
            {
                ViewBag.Course = ID_Course;
                result = new ExpertsDetailtBCL().GetByCoId(ID_Course);
            }
            else
            {
                result = new ExpertsDetailtBCL().GetJoin();
            }
            if (Guid.TryParse(f["Expert"].ToString(), out ID_Expert))
            {
                ViewBag.Expert = ID_Expert;
                result = result.Where(q => q.ExpertId == ID_Expert).ToList();
            }
            return View(result);
        }

        // GET: ExpertsDetailt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpertsDetailt/Create
        [HttpPost]
        public ActionResult Create(ExpertsDetailtObjects ob)
        {
            try
            {
                // TODO: Add insert logic here
                ob.ExId = Guid.NewGuid();
                if (new ExpertsDetailtBCL().Insert(ob))
                    return RedirectToAction("Index");
                else ModelState.AddModelError("", "Tạo mới thất bại");
            }
            catch
            {
            }
            return View();
        }

        // GET: ExpertsDetailt/Edit/5
        public ActionResult Edit(Guid id)
        {
            var ob = new ExpertsDetailtBCL().GetByExId(id);
            ob.CoursesJoin = new CoursesBCL().GetByCoId((Guid)ob.CoId);
            ob.ExpertsJoin = new ExpertsBCL().GetByExpertId((Guid)ob.ExpertId);
            return View(ob);
        }

        // POST: ExpertsDetailt/Edit/5
        [HttpPost]
        public ActionResult Edit(ExpertsDetailtObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (new ExpertsDetailtBCL().Update(ob))
                    return RedirectToAction("Index");
            }
            catch
            {
            }
            return View();
        }

        // POST: ExpertsDetailt/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            return Json(new ExpertsDetailtBCL().Delete(id));
        }
    }
}
