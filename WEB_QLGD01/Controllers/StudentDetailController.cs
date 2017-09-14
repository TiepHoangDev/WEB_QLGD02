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
    public class StudentDetailController : Controller
    {
        //public override Models.eFea GetFea()
        //{
        //    return Models.eFea.QLCTHV;
        //}
        // GET: StudentDetail
        public ActionResult Index()
        {

            return View(new StudentDetailtBCL().GetJoin().Where(x => x.CoursesJoin.Status == false));
        }

        public ActionResult anlyzeUser_byTime(DateTime? start, DateTime? end, bool? Status)
        {
            if (start == null || end == null)
            {
                if (Status == false)
                {
                    ViewBag.test = false;
                    var data = new StudentDetailtBCL().GetJoin().Where(x => x.CoursesJoin.Status == false).ToList();
                    return View("Index", data);
                }
                else
                {
                    ViewBag.test = true;
                    return View("Index", new StudentDetailtBCL().GetJoin().Where(x => x.CoursesJoin.Status == true));
                }
            }
            else
            {
                if (Status == false)
                {
                    return View("Index", new StudentDetailtBCL().GetJoin().Where(x => x.CoursesJoin.Status == true && x.CoursesJoin.StartDate >= start && x.CoursesJoin.EndDate <= end));
                }
                else
                {
                    ViewBag.test = true;
                    return View("Index", new StudentDetailtBCL().GetJoin().Where(x => x.CoursesJoin.Status == true && x.CoursesJoin.StartDate >= start && x.CoursesJoin.EndDate <= end));
                }
            }

        }
        public ActionResult ChiTiet(Guid? ID = null)
        {
            if (!ID.HasValue) return RedirectToAction("Index");
            var data = new StudentBCL().GetByStudetId(ID.Value);
            ViewBag.ChiTietDanhSach = "Học viên " + data.FullName;
            ViewBag.status = data.Status;
            ViewBag.start = "";
            ViewBag.end = "";
            return View("Index", new StudentDetailtBCL().GetJoin().Where(q => q.StudentJoin.StudetId == ID.Value));
        }

        [HttpGet]
        public ActionResult Create(Guid? coursesId)
        {
            List<StudentObjects> LisStudent = new StudentBCL().GetAllNOTCLASS();
            /*FeaIdObject objFeat = LisFeat.Single(x => x.FeaId.Equals(0));
            LisFeat.Remove(objFeat);*/
            ViewBag.ALl = new CoursesBCL().GetAll();
            if (coursesId != null)
            {
                var name = new CoursesBCL().GetByCoId((Guid)coursesId);
                ViewBag.Name = name;
            }
            ViewBag.ListStudent = LisStudent;
            ViewBag.coursesId = coursesId;
            List<CoursesObjects> lisCourses = new CoursesBCL().GetAll();
            /* AccountObject objAccount = lisFeat.Single(x => x.FeaId.Equals(0));
             lisFeat.Remove(objFeat);*/
            ViewBag.ListCourses = lisCourses;
            StudentDetailtObjects ob = new StudentDetailtObjects() { CoId = coursesId };
            return View(ob);

        }
        [HttpPost]
        public JsonResult AddStudentinClass(string StudentID, string ClassID)
        {
            StudentDetailtObjects obj = new StudentDetailtObjects();
            obj.StdId = Guid.NewGuid();
            obj.StudetId = Guid.Parse(StudentID);
            obj.CoId = Guid.Parse(ClassID);
            new StudentDetailtBCL().Insert(obj);
            return Json(new { result = true, message = "Thêm  thành công!" });
        }

        [HttpPost]
        public ActionResult Create(StudentDetailtObjects obj, int IsOption = 0)
        {
            var oke = !new StudentDetailtBCL().GetJoin().Any(q => q.CoId == obj.CoId && q.StudetId == obj.StudetId);
            if (oke)
            {
                obj.StdId = Guid.NewGuid();
                if (new StudentDetailtBCL().Insert(obj))
                    if (IsOption == 0)
                    {
                        return RedirectToAction("Index", "StudentDetail");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Courses");
                    }

                else ModelState.AddModelError("", "Thêm học viên thất bại!");
            }
            else
            {
                List<StudentObjects> LisStudent = new StudentBCL().GetAll();
                ViewBag.ListStudent = LisStudent;
                ModelState.AddModelError("", "Học viên này đã học ở lớp này!");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid ID, int IsOption = 0)
        {
            ViewBag.IsOption = IsOption;
            return View(new StudentDetailtBCL().GetByStdId(ID));
        }
        [HttpPost]
        public ActionResult Edit(StudentDetailtObjects obj, int IsOption = 0)
        {

                if (new StudentDetailtBCL().Update(obj))
                {
                    if(IsOption ==0)
                    {
                        return RedirectToAction("Index", "StudentDetail");
                    }
                    else if(IsOption==2)
                    {
                        return RedirectToAction("ChiTietByHieu", "StudentDetail", new { ID = obj.StudetId });
                    }
                    else 
                    {
                        return RedirectToAction("Edit", "Courses", new { ID =obj.CoId});
                    }
                }
            return View();
        }


        [HttpPost]
        public JsonResult Delete(Guid ID, FormCollection collection)
        {
            return Json(new StudentDetailtBCL().Delete(ID));
        }

        public ActionResult ListStudentByCoursesId(Guid coursesId)
        {
            ViewBag.coursesId = coursesId;
            var list = new StudentDetailtBCL().GetJoin().Where(x => x.CoId.Equals(coursesId)).ToList();
            return PartialView(list);
        }

        [HttpGet]
        public ActionResult ChiTietByHieu(Guid ID)
        {
            return View(new StudentDetailtBCL().GetCourseByStudentId(ID));
        }

    }
}