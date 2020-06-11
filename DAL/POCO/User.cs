using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_HELPERS;

namespace Y_DAL.POCO
{
    public class User
    {
        public Guid ID { get; set; }
        public Guid CutomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ActivationStatus ActivationStatus { get; set; }
        public Boolean IsActive { get; set; }
    }
}
