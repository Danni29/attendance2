using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using OfficeOpenXml;
using System.Web.Mvc;
using Assignment.DB;
using Excel = Microsoft.Office.Interop.Excel;

namespace Assignment.Controllers
{
    public class StudentsController : Controller
    {
        private AttendanceDBEntities db = new AttendanceDBEntities();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Class);
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StID,StName,Password,PortalID,ClassID,Email,Phone")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
          
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StID,StName,Password,PortalID,ClassID,Email,Phone")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ClassID", "ClassName", student.ClassID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ImportExcel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImportToExcel(HttpPostedFileBase excelFile) { 
                
            
                Excel.Application application = new Excel.Application();
                Excel.Workbook workbook = application.Workbooks.Open("D:/Excel/"+excelFile.FileName);
                Excel.Worksheet worksheet = workbook.ActiveSheet;   
                Excel.Range range = worksheet.UsedRange;
               
                for(int row = 2; row <= range.Rows.Count; row++)
                {
                    Student student = new Student();
                    student.StID = ((Excel.Range)range.Cells[row, 1]).Text;
                    student.StName = ((Excel.Range)range.Cells[row, 2]).Text;
                    student.Password = ((Excel.Range)range.Cells[row, 3]).Text;
                    student.PortalID = ((Excel.Range)range.Cells[row, 4]).Text;
                    student.ClassID = ((Excel.Range)range.Cells[row, 5]).Text;
                    student.Email = ((Excel.Range)range.Cells[row, 6]).Text;
                    student.Phone = ((Excel.Range)range.Cells[row, 7]).Text;
                    db.Students.Add(student);
                    db.SaveChanges();
                }

            return RedirectToAction("Index");
        }

        public void ExportToExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var students = db.Students.Include(s => s.Class).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "List Of Student";
            ws.Cells["B1"].Value = "Student";

            ws.Cells["A2"].Value = "List Of Student";
            ws.Cells["B2"].Value = "Student";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = String.Format("{0:dd MM yyyy} at {0: H: mm tt}", DateTimeOffset.Now);


            ws.Cells["A6"].Value = "StID";
            ws.Cells["B6"].Value = "StName";
            ws.Cells["C6"].Value = "Password";
            ws.Cells["D6"].Value = "PortalID";
            ws.Cells["E6"].Value = "ClassID";
            ws.Cells["F6"].Value = "Email";
            ws.Cells["G6"].Value = "Phone";

            int rowstart = 7;
            foreach (var item in students)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.StID;
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.StName;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.Password;
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.PortalID;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.ClassID;
                ws.Cells[String.Format("F{0}", rowstart)].Value = item.Email;
                ws.Cells[String.Format("G{0}", rowstart)].Value = item.Phone;
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
