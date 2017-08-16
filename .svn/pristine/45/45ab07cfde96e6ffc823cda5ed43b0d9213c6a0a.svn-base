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
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            return View(new RoleBCL().GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleObject obj)
        {
            RoleObject objA = new RoleObject();
            objA.RoleId = Guid.NewGuid();
            /*HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }*/
            //objLessonCategory.ModifiedBy =Guid.Parse("5065268F-F180-4061-976E-BB74BAB0DC2E");
            objA.RName = obj.RName;            
            objA.Isdeleted = false;

            new RoleBCL().Insert(objA);
            return RedirectToAction("Create", "Role");

        }

        [HttpGet]
        public ActionResult Edit(System.Guid Id)
        {
            RoleObject objRo = new RoleObject();
            objRo = new RoleBCL().GetByRoleId(Id);
            //objPe.FeaJoin = new FeaIdBCL().GetByFeaId(objPe.FeaId);
            List<RoleObject> LisRo = new RoleBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListRole = LisRo;
            
            return View(objRo);
        }
       

        [HttpPost]

        public ActionResult Edit(RoleObject obj)
        {
            new RoleBCL().Update(obj);
            return RedirectToAction("Index", "Role");
        }

        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
            return Json(new RoleBCL().Delete(ID));
        }
    }
}