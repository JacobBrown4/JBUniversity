using JBUniversity.Data;
using JBUniversity.Models.Cohort;
using JBUniversity.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Service
{
    public class CohortService
    {
        private readonly Guid _userId;
        public CohortService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCohort(CohortCreate model)
        {
            var entity =
                new Cohort()
                {
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cohorts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CohortListItem> GetCohorts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cohorts
                        .Select(
                        e =>
                            new CohortListItem
                            {
                                Id = e.Id,
                                Name = e.Name
                            });
                return query.ToArray();
            }
        }
        public CohortDetail GetCohortById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cohorts
                    .Single(e => e.Id == id);
                return
                    new CohortDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Students = entity.Enrollments.Select(x=> new StudentBasicDetail
                        {
                            StudentName = x.Student.FirstName + " " + x.Student.LastName
                        }).ToList()
                    };
            }
        }
        public bool UpdateCohort(CohortEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Cohorts
                    .Single(e => e.Id == model.Id);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCohort(int cohortId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cohorts
                    .Single(e => e.Id == cohortId);
                ctx.Cohorts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
