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
    public class StudentDetailController : Controller
    {
        // GET: StudentDetail
        public ActionResult Index()
        {
            return View(new StudentDetailtBCL().GetJoin());
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<StudentObjects> LisStudent = new StudentBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListStudent = LisStudent;

            List<CoursesObjects> lisCourses = new CoursesBCL().GetAll();
            /* AccountObject objAccount = lisFeat.Single(x => x.FeaId.Equals(0));
             lisFeat.Remove(objFeat);*/
            ViewBag.ListCourses = lisCourses;
            return View();

        }

        [HttpPost]
        public ActionResult Create(StudentDetailtObjects obj)
        {
            StudentDetailtObjects objStu = new StudentDetailtObjects();
            objStu.StdId = Guid.NewGuid();
            /*HttpPostedFileBase file = Request.Files[0];
            if (file.ContentLength > 0 && file.ContentType.Contains("image"))
            {
                var fileName = DateTime.Now.ToString("ddMMyyyyhhMMss") + "-" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Galleries/Lesson/Categories"), fileName);
                file.SaveAs(path);
                objLessonCategory.CategoryImage = fileName;
            }*/
            //objLessonCategory.ModifiedBy =Guid.Parse("5065268F-F180-4061-976E-BB74BAB0DC2E");
            objStu.StudetId = obj.StudetId;
            objStu.CoId = obj.CoId;
            objStu.Description = obj.Description;
            new StudentDetailtBCL().Insert(objStu);
            return RedirectToAction("Create", "StudentDetail");

        }

        [HttpGet]
        public ActionResult Edit(System.Guid ID)
        {
            StudentDetailtObjects objPe = new StudentDetailtObjects();
            objPe = new StudentDetailtBCL().GetByStdId(ID);
            //objPe.FeaJoin = new FeaIdBCL().GetByFeaId(objPe.FeaId);
            List<StudentObjects> LisStu = new StudentBCL().GetAll();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ListStu = LisStu;

            List<CoursesObjects> lisCourse = new CoursesBCL().GetAll();
            /* AccountObject objAccount = lisFeat.Single(x => x.FeaId.Equals(0));
             lisFeat.Remove(objFeat);*/
            ViewBag.ListCourse = lisCourse;
            return View(objPe);
        }

        [HttpPost]
        public ActionResult Edit(StudentDetailtObjects model)
        {
            new StudentDetailtBCL().Update(model);
            return RedirectToAction("Index", "StudentDetail");
        }


        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
            return Json(new StudentDetailtBCL().Delete(ID));
        }
    }
}