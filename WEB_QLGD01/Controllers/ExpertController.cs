﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class ExpertController : BaseController
    {
        public override Models.eFea GetFea()
        {
            return Models.eFea.QLCG;
        }
        // GET: Expert
        public ActionResult Index(bool? Status)
        {
            if (Status == null)
            {
                Status = false;
            }
            if (Status == false)
            {
                ViewBag.Status = false;
                var list = new ExpertsBCL().GetAll().Where(x=>x.Status==false);
                return View(list);
            }
            else
            {
                ViewBag.Status = true;
                var list = new ExpertsBCL().GetAll().Where(x=>x.Status==true);
                return View(list);
            }
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
            objE.ExpertId = Guid.NewGuid();
            objE.Deleted = false;
            objE.Status = false;
            var lisAcc = new AccountBCL().GetAll().Any(x => x.Username == objE.Email);
            if (lisAcc == false)
            {
                var b = new ExpertsBCL().Insert(objE);
                if (b)
                {
                    AccountObject acc = new AccountObject();
                    acc.UserId = objE.ExpertId;
                    acc.FullName = objE.FullName;
                    acc.PassWord = "nothing";
                    acc.Username = objE.Email;
                    acc.Email = objE.Email;
                    acc.Phone = objE.Mobile;
                    acc.Description = objE.Description;
                    acc.Isdeleted = objE.Deleted;
                    acc.RoleId = Guid.Parse("adae8847-5b4d-43fc-a761-038b315d7651");
                    new AccountBCL().Insert(acc);
                    return RedirectToAction("Index", "Expert");
                }
                else
                {
                    ModelState.AddModelError("", "them moi that bai");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản đã có người sử dụng");
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

            var b = new ExpertsBCL().Update(objE);
            if (b)
            {
                var acc = new AccountBCL().GetByUserId(objE.ExpertId);
                if (acc != null)
                {
                    acc.FullName = objE.FullName;
                    acc.Username = objE.Email;
                    acc.Email = objE.Email;
                    acc.Phone = objE.Mobile;
                    acc.Description = objE.Description;
                    acc.Isdeleted = objE.Status;
                    new AccountBCL().Update(acc);
                }
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
        public JsonResult Delete(Guid ID, FormCollection collection)
        {
            var exper = new ExpertsBCL().Delete(ID);
            return Json(new AccountBCL().Delete(ID));
        }

    }
}

