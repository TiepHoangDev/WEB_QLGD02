using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;


namespace WEB_QLGD01.Controllers
{
    public class FeatIdController : Controller
    {
        // GET: FeatId
        public ActionResult Index()
        {
            return View(new FeaIdBCL().GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FeaIdObject obj)
        {
            FeaIdObject objA = new FeaIdObject();
            objA.FeaId = obj.FeaId;
            /*HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }*/
            //objLessonCategory.ModifiedBy =Guid.Parse("5065268F-F180-4061-976E-BB74BAB0DC2E");
            objA.FeaName = obj.FeaName;
            objA.Isdeleted = false;

            new FeaIdBCL().Insert(objA);
            return RedirectToAction("Create", "FeatId");

        }

        public ActionResult Edit(string Id)
        {
            return View(new FeaIdBCL().GetByFeaId(Id));
        }

        [HttpPost]

        public ActionResult Edit(FeaIdObject obj)
        {
            new FeaIdBCL().Update(obj);
            return RedirectToAction("Index", "FeatId");
        }

        [HttpPost]
        public JsonResult FeatId_Delete(string FeatId)
        {
            try
            {
                new FeaIdBCL().Delete(FeatId);
            }
            catch (Exception e)
            {
                return Json(new { result = false, message = "Đã có lỗi xảy ra!" });
            }
            return Json(new { result = true, message = "Xóa danh mục thành công!" });
        }
    }
}