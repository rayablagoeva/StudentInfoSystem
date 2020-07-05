using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;



namespace UserLogin
{
    class Program
    {

        public static void OnError(string errorMsg)
        {
            Console.WriteLine("Error! " + errorMsg);
        }

        private static void MenuAdmin()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");
            try
            {
                Int16 option = Int16.Parse(Console.ReadLine());
                String username;

                UserContext context = new UserContext();
                switch (option)
                {
                    case 0:
                        Console.WriteLine("Goodbye.");
                        return;
                    case 1:


                        Console.Write("Въведете потребителско име: ");
                        username = Console.ReadLine();
;

                        User usr = (from u in context.Users where u.name == username select u).First();
                        
                                Console.Write("Въведете номер на новата роля: ");
                                try
                                {
                                    Int32 role = Int32.Parse(Console.ReadLine());

                                    UserData.AssignUserRole(usr.name, (UserRoles)role);
                                    Console.WriteLine("Успешна смяна на ролята ");

                                }
                                catch (System.Exception)
                                {
                                    Console.WriteLine("Грешка при разчитането на ролята");
                                    return;
                                }
                        
                        break;

                    case 2:
                        Console.Write("Въведете потребителско име: ");
                        username = Console.ReadLine();

                        User us = (from u in context.Users where u.name == username select u).First();
                      
                                Console.Write("Въведете дата: ");
                                try
                                {
                                    DateTime NewValidTo = DateTime.Parse(Console.ReadLine());
                                    UserData.SetUserActiveTo(us.name, NewValidTo);
                                    Console.WriteLine("Успешно сменена активност ");
                                }
                                catch (System.Exception)
                                {
                                    Console.WriteLine("Грешка при разчитането ");
                                    return;
                                }

                        

                        break;
                    case 3:
                        break;
                    case 4:
                        if (File.Exists("test.txt"))
                        {
                            StreamReader sr = new StreamReader("test.txt");
                            string line;
                            StringBuilder sb = new StringBuilder();
                            while ((line = sr.ReadLine()) != null)
                            {
                                sb.Append(line);
                                sb.Append('\n');
                            }
                            Console.WriteLine(sb.ToString());

                        }
                        break;
                    case 5:
                        Console.WriteLine(LibraryLogger.Logger.GetCurrentSessionActivities());
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("Грешка при разчитането на избраната опция. Моля опитайте отново");
                return;
            }
        }




        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter username: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter passsword: ");
            string password = Console.ReadLine();
            User usr = null;

            if (UserData.TestUserfEmpty() == true)

            {
               
                UserData.CopyTestUser();
            }




            LoginValidation validator = new LoginValidation(userName, password, OnError);
            if (validator.ValidateUserInput(ref usr) == true)
            {
                Console.WriteLine("Username: " + usr.name);
                Console.WriteLine("Faculty Number: " + usr.facNumber);
                Console.WriteLine("Role ID: " + usr.role);



                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You are anomymous");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are admin");
                        MenuAdmin();
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("You are inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("You are professor");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You are student");
                        break;


                }


            }
            //validator.badLogin(userName, password);


        }

    }
}
