using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Y_HELPERS
{
    public class DBHelper
    {
        private static DBHelper instance;

        public SqlConnection Connection { get; set; }

        public static DBHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBHelper();
                }
                return instance;
            }
        }

        private DBHelper()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public static DBHelper GetInstance()
        {
            return Instance;
        }

    }
    public struct SQLTables
    {
        public static string Customer = "Customers";
        public static string Tokens = "Tokens";
        public static string User = "Users";
    }
}
