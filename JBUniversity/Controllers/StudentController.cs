using JBUniversity.Data;
using JBUniversity.Models.Student;
using JBUniversity.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JBUniversity.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            return studentService;
        }
        public IHttpActionResult Get()
        {
            StudentService studentService = CreateStudentService();
            var students = studentService.GetStudents();
            return Ok(students);
        }
        public IHttpActionResult Post(StudentCreate student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStudentService();

            if (!service.CreateStudent(student))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            StudentService studentService = CreateStudentService();
            var student = studentService.GetStudentById(id);
            return Ok(student);
        }

        public IHttpActionResult Put(StudentEdit student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateStudentService();

            if (!service.UpdateStudent(student))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateStudentService();

            if (!service.DeleteStudent(id))
                return InternalServerError();
            return Ok();
        }
    }
}
