using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Assignment.DB;
using Assignment.DTO;
using AutoMapper;

namespace Assignment.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private AttendanceDBEntities db = new AttendanceDBEntities();

        // GET: api/Students
        public IEnumerable<StudentDTO> GetStudents()
        {
            return db.Students.Include(s => s.Class).ToList().Select(Mapper.Map<Student, StudentDTO>);
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {
            var student = db.Students.SingleOrDefault(c => c.StID == id);
            if (student == null)
            {
                return NotFound();
            }
            
            return Ok(Mapper.Map<Student, StudentDTO>(student));
        }

        // PUT: api/Students/5
        [HttpPut]
        public void UpdateStudent(string id, StudentDTO studentDTO)
        {
           
            var studentInDB = db.Students.SingleOrDefault(c => c.StID == id);

            if (studentInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

           Mapper.Map<StudentDTO, Student>(studentDTO, studentInDB);
            db.SaveChanges();
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = Mapper.Map<StudentDTO, Student>(studentDTO);
            db.Students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(new Uri(Request.RequestUri + "" + student.StID), studentDTO);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.Students.Count(e => e.StID == id) > 0;
        }
    }
}