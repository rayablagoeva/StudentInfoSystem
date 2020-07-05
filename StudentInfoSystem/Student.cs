using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentInfoSystem
{
    public class Student
    {
        public string name { get; set; }
        public string secondName { get; set; }
        public string surName { get; set; }
        public string faculty { get; set; }
        public string specialty { get; set; }
        public string degree { get; set; }
        public enum statusTypes { заверил, прекъснал, завършил } 
        public statusTypes status { get; set; }
        public string facNumber { get; set; }
        public int course { get; set; }
        public int potok { get; set; }
        public int group { get; set; }
        public int StudentId { get; set; }
        public Student() { 
        }
        public Student(string name,string secondName,string surName,string faculty,string specialty,string degree,int status,string facNumber,int course, int potok,int group)
        {
            this.name = name;
            this.secondName = secondName;
            this.surName = surName;
            
            this.faculty = faculty;
            this.specialty = specialty;
            this.degree = degree;
            this.status = (statusTypes)status;
            this.facNumber = facNumber;
            this.course = course;
            this.potok = potok;
            this.group = group;






        }
    }

   

}
