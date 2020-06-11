using Y_SERVICE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_SERVICE.Schema
{
    public class TokenResponse : BaseResponse
    {
        public string Token { get; set; }
        public string TokenExpiry { get; set; }
    }
}
