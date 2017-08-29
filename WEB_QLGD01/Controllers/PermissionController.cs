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
    public class PermissionController : Controller
    {
        // GET: Permission
        // Chỉ xem đc account nhỏ hơn quyền hiện tại
        public ActionResult Index()
        {
            var per = new Permission();
            return View(new PermisstionBCL().GetJoin().Where(q => !(per < q.AccountJoin)).OrderByDescending(q => q.AccountJoin.RoleId).ToList());
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

        [HttpGet]
        public ActionResult Create()
        {
            List<FeaIdObject> LisFeat = new FeaIdBCL().GetAll();
            ViewBag.ListFeat = LisFeat;

            List<AccountObject> lisUser = new AccountBCL().GetAll();
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
                    if (new PermisstionBCL().GetJoin().Any(q => q.UserId == ob.UserId && q.FeaId.Trim().ToUpper() == ob.FeaId.Trim().ToUpper()))
                    {
                        ModelState.AddModelError("", "Người dùng đã tồn tại quyền này");
                    }
                    else
                    {
                        if (new PermisstionBCL().Insert(ob))
                        {
                            return RedirectToAction("Index");
                        }
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