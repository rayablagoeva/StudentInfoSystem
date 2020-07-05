using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInfoSystem
{
    class GradesData
    {
        public static List<Grades> TestGrades
        {
            get
            {
                ResetTestGradeData();
                return _testGrades;


            }
            private set { }
        }
        public static List<Grades> _testGrades = new List<Grades>();
        private static void ResetTestGradeData()
        {
            if (_testGrades.Count == 0)
            {
                _testGrades.Add(new Grades(StudentData.TestStudents[0].facNumber, "OIP", "доц.Иванов", 5 ));
                _testGrades.Add(new Grades(StudentData.TestStudents[1].facNumber, "PIK", "проф.Илиев", 5));
                _testGrades.Add(new Grades(StudentData.TestStudents[0].facNumber, "Matematika", "проф.Георгиева ",3));
                _testGrades.Add(new Grades(StudentData.TestStudents[1].facNumber, "Fizika", "доц.Желева", 2));


            }
        }
        public static bool TestGradesEmpty()
        {


            GradesContext context = new GradesContext();
            IEnumerable<Grades> queryGrades = context.Grades;
            int countGrades = queryGrades.Count();

            if (countGrades == 0)
            {
                return true;
            }

            return false;
        }
        public static void CopyTestGrades()
        {
            
            GradesContext context = new GradesContext();
            

            foreach (Grades grade in GradesData.TestGrades)
            {

                context.Grades.Add(grade);
             
             


            }

            context.SaveChanges();





        }
    }

}


