﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessObject.Objects;
using WCF.BussinessController.BCL;
namespace WEB_QLGD01.Controllers
{
    public class CoursesJournalController : Controller
    {
        // GET: CoursesJournal
        public ActionResult Index()
        {
            var list = new CoursesJournalBCL().GetJoin().ToList();
            return View(list);
        }

        // GET: CoursesJournal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoursesJournal/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CoursesJournal/Create
        [HttpPost]
        public ActionResult Create(CoursesJournalObjects objCJ)
        {

            var b = new CoursesJournalBCL().Insert(objCJ);
            if (b)
            {
                return RedirectToAction("Index", "CoursesJournal");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }

        // GET: CoursesJournal/Edit/5
       /* public ActionResult Edit(Guid id)
        {
            var obj = new CoursesJournalBCL().GetByCJId(id);
            //obj.CoursesJoin = new CoursesBCL().GetByCoId((Guid)obj.CoId);

            

            return View(obj);
        }

        // POST: CoursesJournal/Edit/5
        [HttpPost]
        public ActionResult Edit(CoursesJournalObjects objCJ)
        {
            var b = new CoursesJournalBCL().Update(objCJ);
            if (b)
            {
                return RedirectToAction("Index", "CoursesJournal");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }
        */


        [HttpGet]
        public ActionResult Edit(Guid Id)
        {
            CoursesJournalObjects objCourses = new CoursesJournalBCL().GetByCJId(Id);
            List<CoursesObjects> lstCourse = new CoursesBCL().GetAll();
            ViewBag.ListCourse = lstCourse;
            return View(objCourses);
        }
        [HttpPost]
        public ActionResult Edit(CoursesJournalObjects model)
        {           
           var b= new CoursesJournalBCL().Update(model);
            if(b)
            {
                return RedirectToAction("Edit", "CoursesJournal");
            }

            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }
        // GET: CoursesJournal/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {

            return Json(new CoursesJournalBCL().Delete(ID));
        }

       
        
    }
}