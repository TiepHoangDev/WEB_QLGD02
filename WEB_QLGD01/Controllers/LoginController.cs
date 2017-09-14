﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WEB_QLGD01.Models;

namespace WEB_QLGD01.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogin ob)
        {
            if (new Login().CheckLogin(ob))
            {
                //var user = new Models.Login().GetAccount();
                //if(user.RoleId.Equals())
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("result","Đăng nhập thất bại.");
                return View();
            }
        }

        public ActionResult Logout()
        {
            new Login().Logout();
            return RedirectToAction("Index");
        }
    }
}