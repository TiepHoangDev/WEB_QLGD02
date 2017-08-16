using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class ExpertController : Controller
    {
        // GET: Expert
        public ActionResult Index()
        {
            var list = new ExpertsBCL().GetAll().ToList();
            
            return View(list);
        }

        // GET: Expert/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Expert/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expert/Create
        [HttpPost]
        public ActionResult Create(ExpertsObjects objE)
        {
            objE.Deleted = false;
            var b = new ExpertsBCL().Insert(objE);
            if(b)
            {
                return RedirectToAction("Index", "Expert");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
            return View();
        }

        // GET: Expert/Edit/5
        public ActionResult Edit(Guid id)
        {
            var obj = new ExpertsBCL().GetByExpertId(id);
           
            return View(obj);
        }

        // POST: Expert/Edit/5
        [HttpPost]
        public ActionResult Edit(ExpertsObjects objE)
        {
            
          var b=new ExpertsBCL().Update(objE);
            if(b)
            {
                return RedirectToAction("Index", "Expert");
            }
            else
            {
                ModelState.AddModelError("", "them moi that bai");
            }
             return View();
        }

        // GET: Expert/Delete/5
       

        // POST: Expert/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
           
               return Json(new ExpertsBCL().Delete(ID));
        }
            
    }
}

