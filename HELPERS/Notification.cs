using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_HELPERS
{
    public class Notification
    {
        public string code { get; set; }
        public NotificationType type { get; set; }
        public string description { get; set; }
        public string stackTrace { get; set; }
    }
}
