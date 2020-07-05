using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;


namespace StudentInfoSystem
{
    public class StudentValidation
    {
        

            static public Student GetStudentDataByUser(User user)
                {
                if (user.facNumber == null)
                {
                LibraryLogger.Logger.LogActivity("Потребителят няма факултетен номер", user.name, Enum.GetName(typeof(UserRoles), user.role));
                
                return null;
                }
                else
                {
                StudentInfoContext context = new StudentInfoContext();
                Student std = (from s in context.Students where s.facNumber == user.facNumber  select s).First();
                
                    if (std == null)
                    {

                    LibraryLogger.Logger.LogActivity("Няма потребител с такъв факултетен номер", user.name, Enum.GetName(typeof(UserRoles), user.role));
                    return null;

                    }
                    else {
                    
                    return std;

                    }

                  
                    

              
               
                
                //foreach (Student s in StudentData.TestStudents)
                //{
                // if (s.facNumber == user.facNumber)
                // {
                //    return s;
                //}


                //}
                
                }
            }



        }
        }
 

