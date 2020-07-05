using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        static public List<User> _testUsers = new List<User>();
        private static void ResetTestUserData()
        {
            if (_testUsers.Count == 0)
            {
                _testUsers.Add(new User("admin", "password", "121217012", 1, DateTime.Now, DateTime.MaxValue));
                _testUsers.Add(new User("student", "student", "121217067", 4, DateTime.Now, DateTime.Now.AddDays(-1)));
                _testUsers.Add(new User("user", "user", "121213245", 3, DateTime.Now, DateTime.MaxValue));
                _testUsers.Add(new User("student2", "student2", "121217093", 4, DateTime.Now, DateTime.MaxValue));
            }
        }

        public static User IsUserPassCorrect(string name, string password)
        {
            
            UserContext context = new UserContext();
            //ResetTestUserData();
             User usr =(from u in context.Users where u.password == password && u.name == name select u).First();
            return usr;
           
        }
       

        public static void SetUserActiveTo(string name, DateTime validDate)
        {
            UserContext context = new UserContext();

            User usr = (from u in context.Users where u.name == name select u).First();
            usr.validDate = validDate;
            context.SaveChanges();
            LibraryLogger.Logger.LogActivity("Промяна на активност на " + usr.name, LoginValidation.currentUserUsername, Enum.GetName(typeof(UserRoles), LoginValidation.currentUserRole));
           

            // foreach (User usr in _testUsers)
            // {
            //    if (usr.name.Equals(name))
            // {
            //    Logger.LogActivity("Промяна на активност на " + usr.name);
            // usr.validDate = validDate;
            //}

            //}
            
        }

        public static void AssignUserRole(string name , UserRoles role)

        {
            UserContext context =new UserContext();

            User usr =(from u in context.Users where u.name == name select u).First();
            usr.role = (int)role;
            context.SaveChanges();
            LibraryLogger.Logger.LogActivity("Промяна на роля на " + usr.name, LoginValidation.currentUserUsername, Enum.GetName(typeof(UserRoles), LoginValidation.currentUserRole));

            //foreach (User usr in _testUsers)
            //{
            // if (usr.name.Equals(name))
            //{
            //  Logger.LogActivity("Промяна на роля на " + usr.name);
            // usr.role = (int)role;

            //}

            //}
        }
        public static bool TestUserfEmpty()
        {

            UserContext context = new UserContext();
            IEnumerable<User> queryStudents = context.Users;
            int countUser = queryStudents.Count();

            if (countUser == 0)
            {
                return true;
            }

            return false;
        }
        public static void CopyTestUser()
        {
            UserContext context = new UserContext();

            foreach (User us in TestUsers)
            {
                context.Users.Add(us);
            }

            context.SaveChanges();
        }
    }

}

