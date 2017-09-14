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
    public class AccountController : BaseController
    {
        public override Models.eFea GetFea()
        {
            return Models.eFea.QLTK;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View(new AccountBCL().GetJoin().Where(q => !(new Permission() < q)).OrderByDescending(q => q.RoleId).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var acc = new AccountBCL().GetByUserId(id);
            ViewBag.ItMe = acc != null && new Models.Login().GetAccount().UserId == acc.UserId;
            return View(new AccountBCL().GetByUserId(id));
        }

        [HttpPost]
        public ActionResult Edit(AccountObject ob)
        {
            try
            {
                if (new AccountBCL().GetAll().Count(q => q.Username == ob.Username) == 2)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã được sử dụng cho người dùng khác");
                }
                else
                {
                    ob.Isdeleted = false;
                    new AccountBCL().Update(ob);
                    var objExper = new ExpertsBCL().GetByExpertId(ob.UserId);
                    if (objExper != null)
                    {
                        objExper.FullName = ob.FullName;
                        objExper.Email = ob.Username;
                        objExper.Email = ob.Email;
                        objExper.Mobile = ob.Phone;
                        objExper.Description = ob.Description;
                        new ExpertsBCL().Update(objExper);
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Sửa không thành công");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Create(AccountObject obj)
        {
            try
            {
                if (new AccountBCL().GetAll().Any(q => q.Username.Trim().ToLower() == obj.Username.Trim().ToLower()))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã được sử dụng cho người dùng khác");
                }
                else
                {
                    obj.UserId = Guid.NewGuid();
                    obj.Isdeleted = false;
                    if (new AccountBCL().Insert(obj))
                    {
                        return RedirectToAction("Index", "Account");
                    }
                    else ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Có lỗi xảy ra, Liên hệ với Developer");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            return Json(
                new AccountBCL().Delete(id)
                );
        }

    }
}