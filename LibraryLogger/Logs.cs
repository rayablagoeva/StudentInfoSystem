using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogger
{
    public class Logs
    {
        [System.ComponentModel.DataAnnotations.Key]
        public System.Int32 LogId { get; set; }
        public string LogText { get; set; }
        public Logs(String log)
        {
            this.LogText = log;
        }

        public Logs() { }
    }
}
