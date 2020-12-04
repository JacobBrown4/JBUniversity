using JBUniversity.Models.Enrollment;
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
    public class EnrollmentController : ApiController
    {
        private EnrollmentService CreateEnrollmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var enrollmentService = new EnrollmentService(userId);
            return enrollmentService;
        }
        public IHttpActionResult Get()
        {
            EnrollmentService enrollmentService = CreateEnrollmentService();
            var enrollments = enrollmentService.GetEnrollments();
            return Ok(enrollments);
        }
        public IHttpActionResult Post(EnrollmentCreate enrollment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEnrollmentService();

            if (!service.CreateEnrollment(enrollment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            EnrollmentService enrollmentService = CreateEnrollmentService();
            var enrollment = enrollmentService.GetEnrollmentById(id);
            return Ok(enrollment);
        }

        public IHttpActionResult Put(EnrollmentDetail enrollment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEnrollmentService();

            if (!service.UpdateEnrollment(enrollment))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEnrollmentService();

            if (!service.DeleteEnrollment(id))
                return InternalServerError();
            return Ok();
        }
    }
}
