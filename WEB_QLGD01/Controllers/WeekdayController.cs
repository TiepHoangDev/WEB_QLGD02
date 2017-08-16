using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class WeekdayController : Controller
    {
        // GET: Weekday
        public ActionResult Index()
        {
            return View(new WeekdaysBCL().GetAll());
        }

        // GET: Weekday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weekday/Create
        [HttpPost]
        public ActionResult Create(WeekdaysObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ob != null)
                {
                    ob.WeId = Guid.NewGuid();
                    if (new WeekdaysBCL().Insert(ob))
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
            return View(new WeekdaysBCL().GetByWeId(ID));
        }

        // POST: Weekday/Edit/5
        [HttpPost]
        public ActionResult Edit(WeekdaysObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ob != null && new WeekdaysBCL().Update(ob))
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
            return Json(new WeekdaysBCL().Delete(ID));
        }
    }
}
