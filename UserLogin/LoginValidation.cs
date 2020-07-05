
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    public class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserUsername { get; private set; }
        private string userName;
        private string password;
        private string errorMessage;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError errorHandler;



        public LoginValidation(string userName, string password, ActionOnError errorHandler)
        {
            this.userName = userName;
            this.password = password;
            this.errorHandler = new ActionOnError(errorHandler);
        }

        // public void badLogin(string name, string password)
        //{

        //  User u = UserData.IsUserPassCorrect(name, password);
        //  if (u != null)
        //   {
        //    if (DateTime.Compare(u.validDate, DateTime.Today) < 0)
        //{
        //  if (File.Exists("test.txt"))
        //  {
        //  Logger.LogActivity(u.name + " " + "is inactive user tries to login");
        // Console.WriteLine("user is inactive");
        // }



        //  }
        //else
        //  {
        //  Console.WriteLine("user is active");
        //}


        //}


        // }

        public bool ValidateUserInput(ref User u)
        {

            currentUserRole = UserRoles.ANONYMOUS;
            errorMessage = String.Empty;
            Boolean emptyUserName;
            emptyUserName = userName.Equals(String.Empty);
            if (emptyUserName == true)
            {
                errorMessage = "Не е посочено потребителско име";
                errorHandler(errorMessage);
                return false;

            }
            Boolean emptyPassword;
            emptyPassword = password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errorMessage = "Не е посочена парола";
                errorHandler(errorMessage);
                return false;
            }

            if (userName.Length < 5)
            {
                errorMessage = "Потребителското име е по-малка от 5 символа";
                errorHandler(errorMessage);
                return false;
            }
            if (password.Length < 5)
            {
                errorMessage = "Паролата е по-малка от 5 символа";
                errorHandler(errorMessage);

                return false;
            }

            try
            {
                if ((u = UserData.IsUserPassCorrect(userName, password)) != null)
                {
                    currentUserRole = (UserRoles)u.role;
                    currentUserUsername = u.name;
                   LibraryLogger.Logger.LogActivity("Успешен Login", currentUserUsername, Enum.GetName(typeof(UserRoles),currentUserRole));
                }
            } 
            catch (System.Exception)
            {
                errorMessage = "Няма такъв потрeбител";
                LibraryLogger.Logger.LogActivity($"Опит за вписване от несъществуващ потребител с име: {userName} и парола: {password}:", 
                    currentUserUsername, Enum.GetName(typeof(UserRoles), currentUserRole));

                errorHandler(errorMessage);
                return false;
            }

            return true;

        }
        
        
    }
}
