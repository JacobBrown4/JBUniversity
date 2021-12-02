using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Data
{
    public class StudentCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<int> Cohorts { get; set; }
        [Required]
        public int BadgesCompelted { get; set; }
    }
}
