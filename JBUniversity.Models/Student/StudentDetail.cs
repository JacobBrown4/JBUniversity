﻿using JBUniversity.Models.Cohort;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBUniversity.Data
{
    public class StudentDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BadgesCompelted { get; set; }
        public List<CohortListItem> Cohorts { get; set; }
    }
}
