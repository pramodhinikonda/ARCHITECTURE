using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_DAL.DA;
using Y_DAL.POCO;
using Y_SERVICE.Schema;

namespace Y_SERVICE.Service
{
    public class CustomerService
    {
        private CutomerDA CustomerAccess;

        public CustomerService()
        {
            CustomerAccess = new CutomerDA();
        }

        public CustomersResponse GetAll()
        {
            return new CustomersResponse()
            {
                Customers = CustomerAccess.GetAll(),
                success = true
            };
        }

        public CustomerResponse Get(Guid ID)
        {
            return new CustomerResponse()
            {
                Customer = CustomerAccess.Get(ID),
                success = true
            };
        }

        public CustomerResponse Insert(Customer customer)
        {
            return new CustomerResponse()
            {
                Customer = customer,
                success = CustomerAccess.Insert(customer)
            };
        }

        public CustomerResponse Update(Customer customer)
        {
            return new CustomerResponse()
            {
                Customer = customer,
                success = CustomerAccess.Update(customer)
            };
        }

        public CustomerResponse Delete(Guid ID)
        {
            return new CustomerResponse()
            {
                success = CustomerAccess.Delete(ID)
            };
        }
    }
}
