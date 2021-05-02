using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseAndBrand.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName{ get; set; }
        public string Trainer{ get; set; }
        public double Fees{ get; set; }
        public string CourseDescription{ get; set; }
    }
}