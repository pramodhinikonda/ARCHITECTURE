using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_HELPERS;

namespace Y_SERVICE.Common
{
    public class BaseResponse
    {
        public string callerReference { get; set; }
        public Notification notification { get; set; }
        public bool success { get; set; }
    }
}
