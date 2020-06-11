using Y_DAL;
using Y_SERVICE.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_SERVICE
{
    public class UserService
    {
        private UserDA UserAccess;

        public UserService()
        {
            UserAccess = new UserDA();
        }
        public UserResponse Authenticate(string email, string password)
        {
            return new UserResponse()
            {
                User = UserAccess.Authenticate(email, password),
                success = true
            };
        }

        public UserResponse GetUser(string email)
        {
            return new UserResponse()
            {
                User = UserAccess.GetUser(email)
            };
        }
    }
}
