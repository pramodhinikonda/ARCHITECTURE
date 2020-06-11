using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_DAL.POCO;
using Y_HELPERS;
using Dapper;

namespace Y_DAL.DA
{
    public class CutomerDA
    {
        private DBHelper db;

        public CutomerDA()
        {
            db = DBHelper.GetInstance();
        }

        public IEnumerable<Customer> GetAll()
        {
            string query = string.Format("SELECT [ID],[Name],[LogoUrl] FROM {0}", SQLTables.Customer);
            return db.Connection.Query<Customer>(query);
        }

        public Customer Get(Guid ID)
        {
            string query = string.Format("SELECT [ID],[Name],[LogoUrl] FROM {0} WHERE [ID] = @ID", SQLTables.Customer);
            return db.Connection.Query<Customer>(query, new { ID }).FirstOrDefault();
        }

        public bool Insert(Customer customer)
        {
            string query = string.Format("INSERT INTO {0} VALUES(@ID,@Name,@LogoUrl)", SQLTables.Customer);
            var result = db.Connection.Execute(query, new { customer.ID, customer.Name, customer.LogoUrl });
            return result > 0;
        }

        public bool Update(Customer customer)
        {
            string query = string.Format("UPDATE {0} SET [Name] = @Name,[LogoUrl] = @LogoUrl WHERE [ID] = @ID", SQLTables.Customer);
            var result = db.Connection.Execute(query, new { customer.ID, customer.Name, customer.LogoUrl });
            return result > 0;
        }

        public bool Delete(Guid ID)
        {
            string query = string.Format("DELETE FROM {0} WHERE [ID] = @ID", SQLTables.Customer);
            var result = db.Connection.Execute(query, new { ID });
            return result > 0;
        }
    }
}
