using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_DAL.POCO;
using Y_SERVICE.Common;

namespace Y_SERVICE.Schema
{
    public class CustomersResponse : BaseResponse
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}
