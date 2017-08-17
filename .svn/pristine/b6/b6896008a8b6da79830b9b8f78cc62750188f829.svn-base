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
        public ActionResult Index(Guid? ID = null)
        {

            var allCJ = new CoursesStudentDetailtBCL().GetJoin();
            var dropCJ = new List<SelectListItem>();
            Guid idcj = Guid.Empty;
            if (ID.HasValue)
            {
                idcj = (Guid)ID;
                var ob = new CoursesJournalBCL().GetByCJId(idcj);
                ob.CoursesJoin = new CoursesBCL().GetByCoId((Guid)ob.CoId);
                ViewBag.CJ = ob;
            }

            //Tạo drop nhật kí
            dropCJ.Add(new SelectListItem()
            {
                Text = "All",
                Value = "",
                Selected = !ID.HasValue
            });

            foreach (var item in allCJ)
            {
                item.CoursesJournalJoin.CoursesJoin = new CoursesBCL().GetByCoId((Guid)item.CoursesJournalJoin.CoId);
            }

            foreach (var item in allCJ)
            {
                dropCJ.Add(new SelectListItem()
                {
                    Text = "Nhật kí ngày " + item.CoursesJournalJoin.DayOf.Value.ToString("d") + " - Lớp:" + item.CoursesJournalJoin.CoursesJoin.CourseId + " - Nội dung: " + item.CoursesJournalJoin.Contents,
                    Value = item.CJId.ToString(),
                    Selected = item.CJId == idcj
                });
            }
            ViewBag.dropCJ = dropCJ;

            //lấy nhật kí nếu có ID
            if (ID.HasValue)
            {
                allCJ = allCJ.Where(q => q.CJId.Equals(idcj)).ToList();
            }


            return View(allCJ);
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            if (f["sCJ"] == null || string.IsNullOrWhiteSpace(f["sCJ"].ToString()) || f["sCJ"].ToString().Equals(Guid.Empty.ToString())) return RedirectToAction("Index", new { ID = (Guid?)null });
            return RedirectToAction("Index", new { ID = Guid.Parse(f["sCJ"].ToString()) });
        }

        public ActionResult Create(Guid ID)
        {
            var ob = new CoursesJournalBCL().GetByCJId(ID);
            ob.CoursesJoin = new CoursesBCL().GetByCoId((Guid)ob.CoId);
            var dropStuden = new List<SelectListItem>();
            var old = new CoursesStudentDetailtBCL().GetAll().Where(q => q.CJId == ob.CJId).ToList();
            var all = new StudentDetailtBCL().GetJoin().Where(q => q.CoId == ob.CoId && !old.Any(x => x.StudetId == q.StudetId)).ToList();
            foreach (var item in all)
            {
                dropStuden.Add(new SelectListItem()
                {
                    Text = item.StudentJoin.FullName,
                    Value = item.StudetId.ToString()
                });
            }

            ViewBag.CJ = ob;
            ViewBag.dropStuden = dropStuden;
            if (dropStuden.Count <= 0) ModelState.AddModelError("StudetId", "Không có học viên nào trong lớp học để thêm!");

            return View(new CoursesStudentDetailtObject() { CJId = ob.CJId });

        }

        [HttpPost]
        public ActionResult Create(CoursesStudentDetailtObject obj)
        {
            try
            {
                obj.ScsId = Guid.NewGuid();
                if (new CoursesStudentDetailtBCL().Insert(obj))
                {
                    return RedirectToAction("Index", new { ID = (Guid)obj.CJId });
                }
            }
            catch
            {
            }
            return View();

        }

        public ActionResult Edit(Guid ID)
        {
            var ob = new CoursesStudentDetailtBCL().GetByScsId(ID);
            ob.CoursesJournalJoin = new CoursesJournalBCL().GetByCJId((Guid)ob.CJId);
            ob.CoursesJournalJoin.CoursesJoin = new CoursesBCL().GetByCoId((Guid)ob.CoursesJournalJoin.CoId);

            var dropStuden = new List<SelectListItem>();
            var old = new CoursesStudentDetailtBCL().GetAll().Where(q => q.CJId == ob.CJId).ToList();
            var all = new StudentDetailtBCL().GetJoin().Where(q => q.CoId == ob.CoursesJournalJoin.CoId && (!old.Any(x => x.StudetId == q.StudetId) || q.StudetId == ob.StudetId)).ToList();
            foreach (var item in all)
            {
                dropStuden.Add(new SelectListItem()
                {
                    Text = item.StudentJoin.FullName,
                    Value = item.StudetId.ToString(),
                    Selected = item.StudetId == ob.StudetId
                });
            }

            ViewBag.CJ = ob;
            ViewBag.dropStuden = dropStuden;
            return View(ob);
        }

        // POST: CoursesStudentDetailt/Edit/5
        [HttpPost]
        public ActionResult Edit(CoursesStudentDetailtObject ob, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (new CoursesStudentDetailtBCL().Update(ob))
                    return RedirectToAction("Index", new { ID = ob.CJId });
            }
            catch
            {
            }
            return View(ob.ScsId);
        }

        // GET: CoursesStudentDetailt/Delete/5


        // POST: CoursesStudentDetailt/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid ID)
        {
            return Json(new CoursesStudentDetailtBCL().Delete(ID));
        }
    }
}
