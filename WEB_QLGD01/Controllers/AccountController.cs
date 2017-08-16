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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View(new AccountBCL().GetJoin());
        }

        public ActionResult Create()
        {
            return View();
        }        

       /* public ActionResult Edit(System.Guid Id)
        {       
            return View(new AccountBCL().GetByUserId(Id));
        }*/

       /*  public ActionResult Edit(System.Guid Id)
        {       
            return View(new AccountBCL().GetByUserId(Id));
        }*/

        [HttpGet]
        public ActionResult Edit(System.Guid ID)
        {
            AccountObject objAc = new AccountObject();
            objAc = new AccountBCL().GetByUserId(ID);
            //objPe.FeaJoin = new FeaIdBCL().GetByFeaId(objPe.FeaId);
            List<RoleObject> LisRo = new RoleBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListRo = LisRo;
            return View(objAc);
        }

        [HttpPost]
       
        public ActionResult Edit(AccountObject obj)
        {
            obj.Isdeleted = false;
            new AccountBCL().Update(obj);
            return RedirectToAction("Index", "Account");
        }

        

        [HttpPost]
        public ActionResult Create(AccountObject obj)
        {   
            AccountObject objA = new AccountObject();
            objA.UserId = Guid.NewGuid();
            /*HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }*/
            //objLessonCategory.ModifiedBy =Guid.Parse("5065268F-F180-4061-976E-BB74BAB0DC2E");
            objA.FullName = obj.FullName;
            objA.Username = obj.Username;
            objA.PassWord = obj.PassWord;
            objA.Email = obj.Email;
            objA.Isdeleted = false;
            objA.Phone = obj.Phone;
            objA.Description = obj.Description;
            objA.RoleId = Guid.Parse("adae8847-5b4d-43fc-a761-038b315d7651");
            new AccountBCL().Insert(objA);
            return RedirectToAction("Index", "Account");
            
        }

        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            return Json(new AccountBCL().Delete(id));
        }

        

        
    }
}