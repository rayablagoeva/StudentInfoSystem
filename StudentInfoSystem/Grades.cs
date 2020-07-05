using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{

    public class Grades
    {


        [Key]
        public int GradesId { get; set; }
        public string facNumber { get; set; }
        public string subjects { get; set; }
        public string teacher { get; set; }
        public double grades { get; set; }

        public Grades(string facNumber, string subject, string teacher, double grades)
        {

            this.facNumber = facNumber;
            this.subjects = subject;
            this.teacher = teacher;
            this.grades = grades;
        }

        public Grades() { }

    }
}

