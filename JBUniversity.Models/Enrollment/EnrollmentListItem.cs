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
        public string Class { get; set; }
        public string  Student { get; set; }
    }
}
