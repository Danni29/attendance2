using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment.DB;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;

namespace Assignment.Controllers
{
    public class SubjectsOfClassesController : Controller
    {
        private AttendanceDBEntities db = new AttendanceDBEntities();

        // GET: SubjectsOfClasses
        public ActionResult Index()
        {
            var subjectsOfClasses = db.SubjectsOfClasses.Include(s => s.Class).Include(s => s.Lecturer).Include(s => s.Subject);
            return View(subjectsOfClasses.ToList());
        }

        // GET: SubjectsOfClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname");
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName");
            return View();
        }

        // POST: SubjectsOfClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubOfClaID,SubID,ClassID,LecID,StartDate,EndDate,Hours,SlotTime,Status")] SubjectsOfClass subjectsOfClass)
        {
            if (ModelState.IsValid)
            {
                db.SubjectsOfClasses.Add(subjectsOfClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // POST: SubjectsOfClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubOfClaID,SubID,ClassID,LecID,StartDate,EndDate,Hours,SlotTime,Status")] SubjectsOfClass subjectsOfClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subjectsOfClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", subjectsOfClass.ClassID);
            ViewBag.LecID = new SelectList(db.Lecturers, "LecID", "Fullname", subjectsOfClass.LecID);
            ViewBag.SubID = new SelectList(db.Subjects, "SubID", "SubName", subjectsOfClass.SubID);
            return View(subjectsOfClass);
        }

        // GET: SubjectsOfClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            if (subjectsOfClass == null)
            {
                return HttpNotFound();
            }
            return View(subjectsOfClass);
        }

        // POST: SubjectsOfClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubjectsOfClass subjectsOfClass = db.SubjectsOfClasses.Find(id);
            db.SubjectsOfClasses.Remove(subjectsOfClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ImportExcel()
        {
            return View();
        }
        public ActionResult ImportToExcel(HttpPostedFileBase excelFile)
        {

            string fileName = Path.GetFileName(excelFile.FileName);
            string path = Path.Combine(Server.MapPath("~/Content"), fileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            excelFile.SaveAs(path);
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(path);
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            Excel.Range range = worksheet.UsedRange;

            for (int row = 2; row <= range.Rows.Count; row++)
            {
                SubjectsOfClass subjectsOfClass = new SubjectsOfClass();
                subjectsOfClass.SubOfClaID = ((Excel.Range)range.Cells[row, 1]).Text;
                subjectsOfClass.SubID = ((Excel.Range)range.Cells[row, 2]).Text;
                subjectsOfClass.ClassID = ((Excel.Range)range.Cells[row, 3]).Text;
                subjectsOfClass.LecID = ((Excel.Range)range.Cells[row, 4]).Text;
                subjectsOfClass.StartDate = ((Excel.Range)range.Cells[row, 5]).Text;
                subjectsOfClass.EndDate = ((Excel.Range)range.Cells[row, 6]).Text;
                subjectsOfClass.Hours = ((Excel.Range)range.Cells[row, 7]).Text;
                subjectsOfClass.SlotTime = ((Excel.Range)range.Cells[row, 8]).Text;
                subjectsOfClass.Status = ((Excel.Range)range.Cells[row, 9]).Text;
                db.SubjectsOfClasses.Add(subjectsOfClass);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public void ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var subjectsOfClass = db.SubjectsOfClasses.Include(s => s.Class).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "List Of subjectsOfClass";
            ws.Cells["B1"].Value = "subjectsOfClass";

            ws.Cells["A2"].Value = "List Of subjectsOfClass";
            ws.Cells["B2"].Value = "subjectsOfClass";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = String.Format("{0:dd MM yyyy} at {0: H: mm tt}", DateTimeOffset.Now);


            ws.Cells["A6"].Value = "SubOfClaID";
            ws.Cells["B6"].Value = "SubID";
            ws.Cells["C6"].Value = "ClassID";
            ws.Cells["D6"].Value = "LecID";
            ws.Cells["E6"].Value = "StartDate";
            ws.Cells["F6"].Value = "EndDate";
            ws.Cells["G6"].Value = "Hours";
            ws.Cells["H6"].Value = "SlotTime";
            ws.Cells["I6"].Value = "Status";

            int rowstart = 7;
            foreach (var item in subjectsOfClass)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.SubOfClaID;
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.SubID;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.ClassID;
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.LecID;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.StartDate;
                ws.Cells[String.Format("F{0}", rowstart)].Value = item.EndDate;
                ws.Cells[String.Format("G{0}", rowstart)].Value = item.Hours;
                ws.Cells[String.Format("H{0}", rowstart)].Value = item.SlotTime;
                ws.Cells[String.Format("I{0}", rowstart)].Value = item.Status;
                rowstart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
