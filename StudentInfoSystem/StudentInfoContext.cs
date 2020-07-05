using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentInfoSystem
{
    class StudentInfoContext: DbContext

    {
    
             public DbSet<Student> Students { get; set; }

        public StudentInfoContext() :
            base("Server=DESKTOP-2LTM5RR\\SQLEXPRESS;" +
            "Initial Catalog=StudentInfoDatabase;" +
            "Integrated Security=true;" +
            "Trusted_Connection=true;" +
            "MultipleActiveResultSets=true")
        {
        }
        

    }
}
