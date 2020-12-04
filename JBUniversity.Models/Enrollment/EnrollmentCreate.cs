using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models.Enrollment
{
    public class EnrollmentCreate
    {
        [Required]
        public int CohortId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
