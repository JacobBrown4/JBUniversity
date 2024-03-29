﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public int BadgesCompleted { get; set; }

        public virtual List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public string FullName() => $"{FirstName} {LastName}";
    }
}
