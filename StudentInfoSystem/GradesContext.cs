using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentInfoSystem
{
    class GradesContext : DbContext
    {
        public DbSet<Grades> Grades { get; set; }

        public GradesContext() :
            base("Server=DESKTOP-2LTM5RR\\SQLEXPRESS;" +
            "Initial Catalog=StudentInfoDatabase;" +
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true")
        {
        }

    }
}
