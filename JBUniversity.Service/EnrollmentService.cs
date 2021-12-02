using JBUniversity.Data;
using JBUniversity.Models.Enrollment;
using JBUniversity.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Service
{
    public class EnrollmentService
    {
        private readonly Guid _userId;
        public EnrollmentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEnrollment(EnrollmentCreate model)
        {
            var entity =
                new Enrollment()
                {
                    CohortId = model.CohortId,
                    StudentId = model.StudentId
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EnrollmentListItem> GetEnrollments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Enrollments.ToArray();
                        
                return query.Select(
                        e =>
                            new EnrollmentListItem
                            {
                                Id = e.Id,
                                Student =e.Student.FullName(),
                                Class = e.Cohort.Name

                            }).ToArray();
            }
        }
        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Enrollments
                    .Single(e => e.Id == id);
                return
                    new EnrollmentDetail
                    {
                        Id = entity.Id,
                        StudentId = entity.StudentId,
                        Student = new StudentListItem
                        {
                            Name = entity.Student.FullName(),
                            Id = entity.Student.Id
                        },
                        CohortId = entity.CohortId,
                        Cohort = new Models.Cohort.CohortListItem
                        {
                            Name = entity.Cohort.Name,
                            Id = entity.Cohort.Id
                        }
                    };
            }
        }
        public bool UpdateEnrollment(EnrollmentDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Enrollments
                    .Single(e => e.Id == model.Id);

                entity.CohortId = model.CohortId;
                entity.StudentId = model.StudentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEnrollment(int enrollmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Enrollments
                    .Single(e => e.Id == enrollmentId);
                ctx.Enrollments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
