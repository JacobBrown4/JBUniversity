﻿using JBUniversity.Models.Student;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Models.Cohort
{
    public class CohortDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentListItem> Students { get; set; }
    }
}
