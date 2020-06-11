using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_DAL.POCO
{
    public class Customer
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }
    }
}
