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
    public class StudentService
    {
        private readonly Guid _userId;
        public StudentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateStudent(StudentCreate model)
        {
            var entity =
                new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Students.Add(entity);
                ctx.SaveChanges();
                int iD = ctx.Students.AsEnumerable().Last().Id;
                foreach (int cohort in model.Cohorts)
                {
                    Enrollment enroll = new Enrollment
                    {
                        CohortId = cohort,
                        StudentId = iD
                    };
                    ctx.Enrollments.Add(enroll);
                };
                return ctx.SaveChanges() > -1;
            }
        }
    
    public IEnumerable<StudentListItem> GetStudents()
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                    .Students
                    .Select(
                    e =>
                        new StudentListItem
                        {
                            Id = e.Id,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        });
            return query.ToArray();
        }
    }
    public StudentDetail GetStudentById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity = ctx
                .Students
                .Single(e => e.Id == id);
            return
                new StudentDetail
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Cohorts = entity.Enrollments.Select(c => new CohortListItem
                    {
                        Name = c.Cohort.Name
                    }).ToList()
                };
        }
    }
    public bool UpdateStudent(StudentEdit model)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity = ctx
                .Students
                .Single(e => e.Id == model.Id);

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;

            return ctx.SaveChanges() == 1;
        }
    }

    public bool DeleteStudent(int studentId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                .Students
                .Single(e => e.Id == studentId);
            ctx.Students.Remove(entity);
            return ctx.SaveChanges() == 1;
        }
    }
}
}
