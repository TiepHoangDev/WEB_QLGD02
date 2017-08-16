using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;
using WEB_QLGD01.Models;

namespace WEB_QLGD01.Controllers
{
    public class PermissionController : Controller
    {
        // GET: Permission
        public ActionResult Index()
        {
            return View(new PermisstionBCL().GetJoin());
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var result = new PermisstionBCL().GetJoin();
            Guid UserId = new Guid();
            string FeaId = null;
            if (f["UserId"] != null && Guid.TryParse(f["UserId"].ToString(), out UserId))
            {
                ViewBag.UserId = UserId;
                result = result.Where(q => q.UserId == UserId).ToList();
            }
            if (f["FeaId"] != null && !string.IsNullOrWhiteSpace(f["FeaId"].ToString()))
            {
                FeaId = f["FeaId"].ToString();
                ViewBag.FeaId = FeaId;
                result = result.Where(q => q.FeaId.Trim().ToLower() == FeaId.Trim().ToLower()).ToList();
            }

            return View(result);
        }

        //public ActionResult Create()
        //{
        //    //var select = new List<SelectListItem>();
        //    //var result = new PermisstionBCL().GetJoin().Where(q => q.UserId == id).ToList();
        //    //foreach (var item in new FeaIdBCL().GetAll())
        //    //{
        //    //    if (!result.Any(q => q.FeaId.Trim().ToUpper() == item.FeaId.Trim().ToUpper()))
        //    //    {
        //    //        select.Add(new SelectListItem()
        //    //        {
        //    //            Text = item.FeaId + " - " + item.FeaName,
        //    //            Value = item.FeaId
        //    //        });
        //    //    }
        //    //}
        //    //ViewBag.SelectUser = select;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(PermisstionObject ob, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        new PermisstionBCL().Insert(ob);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult Create()
        {
            List<FeaIdObject> LisFeat = new FeaIdBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListFeat = LisFeat;

            List<AccountObject> lisUser = new AccountBCL().GetAll();
            /* AccountObject objAccount = lisFeat.Single(x => x.FeaId.Equals(0));
             lisFeat.Remove(objFeat);*/
            ViewBag.ListUser = lisUser;
            return View();

        }

        [HttpPost]
        public ActionResult Create(PermisstionObject ob, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ob != null)
                {
                    ob.PerID = Guid.NewGuid();
                    if (new PermisstionBCL().Insert(ob))
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

        [HttpPost]
        public ActionResult Edit(string action, PermisstionObject ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                switch (action)
                {
                    case "save":
                        if (new PermisstionBCL().Update(ob))
                        {
                            return Json(new PermisstionBCL().GetByPerID(ob.PerID));
                        }
                        break;
                    case "delete":
                        return Json(ob != null && new PermisstionBCL().Delete(ob.PerID));
                    default:
                        break;
                }
            }
            catch
            {
            }
            return Json(null);
        }
    }
}