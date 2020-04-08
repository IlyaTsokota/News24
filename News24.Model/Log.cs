using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News24.Model
{
    public class Log
    {
        public int LogId { get; set; }

        public DateTime Date { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }
    }
}
