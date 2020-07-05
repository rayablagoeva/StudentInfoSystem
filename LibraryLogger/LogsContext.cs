using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryLogger
{
    public class LogContext : DbContext
    {
        public DbSet<Logs> UserLogs { get; set; }

        public LogContext() :
             base("Server=DESKTOP-2LTM5RR\\SQLEXPRESS;" +
            "Initial Catalog=StudentInfoDatabase;" +
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true")
        {
        }
    }
}
