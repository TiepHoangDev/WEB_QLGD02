﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.BussinessController.BCL;
using WCF.BussinessObject.Objects;

namespace WEB_QLGD01.Controllers
{
    public class ExpertsDetailtController :BaseController
    {
        public override Models.eFea GetFea()
        {
            return Models.eFea.QLCTGV;
        }
        // GET: ExpertsDetailt
        public ActionResult Index(Guid? id_lop = null)
        {
            if (id_lop.HasValue)
            {
                ViewBag.Course = id_lop;
                return View(new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertsJoin.Status == false && q.CoId == id_lop.Value).OrderBy(w => w.ExpertsJoin.Status));
            }
            else
            {
                return View(new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertsJoin.Status == false).OrderBy(w => w.ExpertsJoin.Status));
            }
        }

        [HttpPost]
        public JsonResult GetLopHoc(Guid idGV)
        {
            string r = "";
            foreach (var item in new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertId == idGV))
            {
                r += string.Format("<option value='{0}'>{1}</option>", item.CoId, item.CoursesJoin.CourseId);
            }
            return Json(r);
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var result = new List<ExpertsDetailtObjects>();
            Guid ID_Expert = new Guid();
            Guid ID_Course = new Guid();
            if (Guid.TryParse(f["Course"].ToString(), out ID_Course))
            {
                ViewBag.Course = ID_Course;
                result = new ExpertsDetailtBCL().GetByCoId(ID_Course);
            }
            else
            {
                result = new ExpertsDetailtBCL().GetJoin();
            }
            if (Guid.TryParse(f["Expert"].ToString(), out ID_Expert))
            {
                ViewBag.Expert = ID_Expert;
                result = result.Where(q => q.ExpertId == ID_Expert).ToList();
            }
            return View(result);
        }

        // GET: ExpertsDetailt/Create
        public ActionResult Create(Guid? id_Course = null, Guid? id_expert = null)
        {
            ViewBag.ALl = new CoursesBCL().GetAll();
            if (id_Course != null)
            {
                var name = new CoursesBCL().GetByCoId((Guid)id_Course);
                ViewBag.Name = name;
            }
            ViewBag.id_Course = id_Course;
            ViewBag.Teacher = new ExpertsBCL().GetAll();
            return View(new ExpertsDetailtObjects());
        }
        [HttpPost]
        public JsonResult AddExpertINClass(Guid ExpertID, Guid ClassID)
        {
            var oke = !new ExpertsDetailtBCL().GetJoin().Any(q => q.ExpertId == ExpertID && q.CoId == ClassID);
            if(oke)
            {
                ExpertsDetailtObjects obj = new ExpertsDetailtObjects();
                obj.ExId = Guid.NewGuid();
                obj.ExpertId = ExpertID;
                obj.CoId = ClassID;
                new ExpertsDetailtBCL().Insert(obj);
                return Json(new { result = true, message = "Thêm  thành công!" });
            }
            return Json(new { result = false, message = "Đã Tồn Tại Rồi!" });
        }
        // POST: ExpertsDetailt/Create
        [HttpPost]
        public ActionResult Create(ExpertsDetailtObjects ob, int IsOption =0)
        {
            try
            {
                // TODO: Add insert logic here
                var oke = !new ExpertsDetailtBCL().GetJoin().Any(q => q.ExpertId == ob.ExpertId && q.CoId == ob.CoId);
                if (oke)
                {
                    ob.ExId = Guid.NewGuid();
                    if (new ExpertsDetailtBCL().Insert(ob))
                        if (IsOption==0)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Courses");
                        }
                    else ModelState.AddModelError("", "Tạo mới thất bại");
                }
                else
                {
                    ModelState.AddModelError("", "Giáo viên này đang dạy lớp hiện tại");
                }
            }
            catch
            {
            }
            return View(ob);
        }

        // GET: ExpertsDetailt/Edit/5
        public ActionResult Edit(Guid id ,int IsOption =0)
        {
            var ob = new ExpertsDetailtBCL().GetByExId(id);
            ob.CoursesJoin = new CoursesBCL().GetByCoId((Guid)ob.CoId);
            ob.ExpertsJoin = new ExpertsBCL().GetByExpertId((Guid)ob.ExpertId);
            ViewBag.IsOption = IsOption;
            return View(ob);
        }

        // POST: ExpertsDetailt/Edit/5
        [HttpPost]
        public ActionResult Edit(ExpertsDetailtObjects ob, FormCollection collection, int IsOption = 0)
        {
            //try
            //{
                // TODO: Add update logic here
                //var oke = new ExpertsDetailtBCL().GetJoin().Count(q => q.ExpertId == ob.ExpertId && q.CoId == ob.CoId) == 1;
                //if (oke)
                //{
                    if (new ExpertsDetailtBCL().Update(ob))
                    {
                        if (IsOption == 0)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Edit", "Courses", new { ID = ob.CoId });
                        }
                    }
                        
                       
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Không thêm giáo viên dạy một lớp quá hai lần!");
            //    }
            //}
            //catch
            //{
            //}
            return View();
        }

        // POST: ExpertsDetailt/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            return Json(new ExpertsDetailtBCL().Delete(id));
        }

        public PartialViewResult search(Guid? id_gv = null, Guid? id_lop = null, bool status = false, DateTime? start = null, DateTime? end = null)
        {
            var data = new ExpertsDetailtBCL().GetJoin().Where(q => q.CoursesJoin.Status == status);

            if (id_gv.HasValue)
            {
                data = data.Where(q => q.ExpertsJoin.ExpertId == id_gv);
            }
            if (id_lop.HasValue)
            {
                data = data.Where(q => q.CoursesJoin.CoId == id_lop);
            }
            if (start.HasValue)
            {
                data = data.Where(q => q.CoursesJoin.StartDate >= start.Value);
            }
            if (end.HasValue)
            {
                data = data.Where(q => q.CoursesJoin.EndDate <= end.Value);
            }
            data = data.OrderBy(w => w.ExpertsJoin.Status);
            return PartialView("pv_ChiTietGiaoVien", data);
        }


        public JsonResult loadDrop(Guid? id, int type)
        {
            string r = "";
            switch (type)
            {
                case 1: //get lophoc
                    r += string.Format("<option value>Tất cả lớp học</option>");
                    IEnumerable<CoursesObjects> lophoc = id.HasValue ? new ExpertsDetailtBCL().GetJoin().Where(q => q.CoursesJoin.Status != true && q.CoursesJoin.CoId == id.Value).Select(m => m.CoursesJoin) : new CoursesBCL().GetAll().Where(q => q.Status != true);
                    foreach (var item in lophoc)
                    {
                        r += string.Format("<option value='{0}'>{1}</option>", item.CoId, item.CourseId);
                    }
                    break;
                case 2: //get giaoVien
                    r += string.Format("<option value>Tất cả Giáo viên</option>");
                    IEnumerable<ExpertsObjects> giaoVien = id.HasValue ? new ExpertsDetailtBCL().GetJoin().Where(q => q.ExpertsJoin.Status != true && q.ExpertsJoin.ExpertId == id.Value).Select(m => m.ExpertsJoin) : new ExpertsBCL().GetAll().Where(q => q.Status != true);
                    foreach (var item in giaoVien)
                    {
                        r += string.Format("<option value='{0}'>{1}</option>", item.ExpertId, item.FullName);
                    }
                    break;
                default:
                    break;
            }
            return Json(r);
        }

        public ActionResult GetListExpertsByCoursesId(Guid? coursesId)
        {
            ViewBag.coursesId = coursesId;
            var list = new ExpertsDetailtBCL().GetJoin().Where(x => x.CoId.Equals(coursesId)).ToList();
            return PartialView(list);
        }
    }
}
