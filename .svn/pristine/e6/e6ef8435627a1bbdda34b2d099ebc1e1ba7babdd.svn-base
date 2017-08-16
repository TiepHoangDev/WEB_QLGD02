using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class ShiftDayController : Controller
    {
        // GET: Weekday
        public ActionResult Index()
        {
            return View(new ShiftDayBCL().GetAll());
        }

        // GET: Weekday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Weekday/Create
        [HttpPost]
        public ActionResult Create(ShiftDayObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ob != null)
                {
                    ob.ShiftId = Guid.NewGuid();
                    if (new ShiftDayBCL().Insert(ob))
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
            return View(new ShiftDayBCL().GetByShiftId(ID));
        }

        // POST: Weekday/Edit/5
        [HttpPost]
        public ActionResult Edit(ShiftDayObjects ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ob != null && new ShiftDayBCL().Update(ob))
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
            return Json(new ShiftDayBCL().Delete(ID));
        }
    }
}
