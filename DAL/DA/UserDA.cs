using Y_DAL.POCO;
using Dapper;
using Y_HELPERS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y_DAL
{
    public class UserDA
    {
        private DBHelper db;

        public UserDA()
        {
            db = DBHelper.GetInstance();
        }

        public User Authenticate(string email, string password)
        {
            var query = string.Format("SELECT [ID],[Email],[Password],[IsActive] FROM {0} WHERE Email = @Email AND Password = @Password", SQLTables.User);
            return db.Connection.Query<User>(query, new { Email = email, Password = password }).FirstOrDefault();
        }

        public User GetUser(string email)
        {
            var query = string.Format("SELECT [ID],[Email],[Password],[IsActive] FROM {0} WHERE [Email] = @Email", SQLTables.User);
            return db.Connection.Query<User>(query, new { Email = email }).FirstOrDefault();
        }
    }
}
