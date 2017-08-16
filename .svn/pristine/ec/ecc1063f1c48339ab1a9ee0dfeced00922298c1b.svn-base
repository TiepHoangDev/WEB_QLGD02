using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessObject.Objects;
using WCF.BussinessController.BCL;
namespace WEB_QLGD01.Controllers
{
    public class CoursesStudentDetailtController : Controller
    {
        // GET: CoursesStudentDetailt
        public ActionResult Index()
        {
            var list = new CoursesStudentDetailtBCL().GetJoin();

            return View(list);
        }

        // GET: CoursesStudentDetailt/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<StudentObjects> LisStudent = new StudentBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListStudent = LisStudent;

            List<CoursesStudentDetailtObject> lisCoursesStudent = new CoursesStudentDetailtBCL().GetAll();
            /* AccountObject objAccount = lisFeat.Single(x => x.FeaId.Equals(0));
             lisFeat.Remove(objFeat);*/
            ViewBag.ListCoursesStudent = lisCoursesStudent;
            return View();

        }

        [HttpPost]
        public ActionResult Create(CoursesStudentDetailtObject obj)
        {
            CoursesStudentDetailtObject objCoS = new CoursesStudentDetailtObject();
            objCoS.ScsId= Guid.NewGuid();
            /*HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }*/
            //objLessonCategory.ModifiedBy =Guid.Parse("5065268F-F180-4061-976E-BB74BAB0DC2E");
            objCoS.StudetId = obj.StudetId;
            objCoS.CJId = obj.CJId;
            objCoS.Description = obj.Description;
            new CoursesStudentDetailtBCL().Insert(objCoS);
            return RedirectToAction("Create", "CoursesStudentDetailt");

        }
       
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoursesStudentDetailt/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CoursesStudentDetailt/Delete/5


        // POST: CoursesStudentDetailt/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            return Json(new CoursesStudentDetailtBCL().Delete(id));
        }
    }
}
