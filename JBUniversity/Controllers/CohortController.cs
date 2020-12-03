using JBUniversity.Models.Cohort;
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
    public class CohortController : ApiController
    {
        private CohortService CreateCohortService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var cohortService = new CohortService(userId);
            return cohortService;
        }
        public IHttpActionResult Get()
        {
            CohortService cohortService = CreateCohortService();
            var cohorts = cohortService.GetCohorts();
            return Ok(cohorts);
        }
        public IHttpActionResult Post(CohortCreate cohort)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCohortService();

            if (!service.CreateCohort(cohort))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CohortService cohortService = CreateCohortService();
            var cohort = cohortService.GetCohortById(id);
            return Ok(cohort);
        }

        public IHttpActionResult Put(CohortEdit cohort)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCohortService();

            if (!service.UpdateCohort(cohort))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCohortService();

            if (!service.DeleteCohort(id))
                return InternalServerError();
            return Ok();
        }
    }
}
