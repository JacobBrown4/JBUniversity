using JBUniversity.Models.Cohort;
using JBUniversity.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models.Enrollment
{
    public class EnrollmentListItem
    {
        public int Id { get; set; }
        public int CohortId { get; set; }
        public CohortListItem Cohort { get; set; }
        public int StudentId { get; set; }
        public StudentListItem Student { get; set; }
    }
}
