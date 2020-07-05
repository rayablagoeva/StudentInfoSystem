using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentInfoSystem
{
    static class  StudentData
    {
        public static List<Student> TestStudents  { get 
            {
                ResetTestStudentData();
                return _testStudents;

            
            } private set { }
        }
        public static List<Student> _testStudents = new List<Student>();
        private static void ResetTestStudentData()
        {
            if (_testStudents.Count == 0)
            {
                _testStudents.Add(new Student("Ина", "Иванова", "Иванова", "ФКСТ", "KСИ", "бакалавър", 2,"121217067",3,9,43 )) ;
                _testStudents.Add(new Student("Ива", "Иванова", "Иванова", "ФКСТ", "KСИ", "бакалавър", 2, "121217093", 3, 7, 39));
               
            }
        }
        public static bool TestStudentsIfEmpty()
        {

            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            if (countStudents == 0)
            {
                return true;
            }

            return false;
        }
        public static void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
        

           
                foreach (Student us in TestStudents)
                {
                    context.Students.Add(us);
                }

                context.SaveChanges();

            
            


        }
        
    }
}
