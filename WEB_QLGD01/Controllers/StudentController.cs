﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;
namespace WEB_QLGD01.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(bool status=false)
        {
            ViewBag.status = status;
            return View(new StudentBCL().GetAll().Where(q => q.Status == status));
        }


        public ActionResult Create()
        {
            return View();
        }
        // POST: Expert/Create
        [HttpPost]
        public ActionResult Create(StudentObjects objS)
        {
            objS.Deleted = false;
            objS.Status = false;
            var b = new StudentBCL().Insert(objS);
            if (b)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var obj = new StudentBCL().GetByStudetId(id);

            return View(obj);
        }

        // POST: Expert/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentObjects objS)
        {
            objS.Deleted = false;
            var b = new StudentBCL().Update(objS);
            if (b)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                ModelState.AddModelError("", "Edit that bai");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
            return Json(new StudentBCL().Delete(ID));
        }
    }
}