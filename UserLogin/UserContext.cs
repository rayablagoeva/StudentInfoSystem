using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UserLogin
{
    class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() :
            base("Server=DESKTOP-2LTM5RR\\SQLEXPRESS;" +
            "Initial Catalog=StudentInfoDatabase;" +
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true")
        {
        }

    }
}
