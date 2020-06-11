using System;
using Y_DAL.POCO;
using Y_SERVICE.Common;

namespace Y_SERVICE.Schema
{
    public class CustomerResponse : BaseResponse
    {
        public Customer Customer { get; set; }
    }
}
