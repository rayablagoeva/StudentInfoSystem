using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class Dissertations
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int DissertationId { get; set; }
        public string facNumberStudent { get; set; }
        public string topic { get; set; }
        public string subject { get; set; }
        public string professor { get; set; }

        public Dissertations(string facNumberStudent, string topic, string subject, string professor)
        {
            facNumberStudent = this.facNumberStudent;
            topic = this.topic;
            subject = this.subject;
            professor = this.professor;



        }
        public Dissertations() { }
    }
}
