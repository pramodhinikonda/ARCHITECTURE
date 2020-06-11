using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Y_DAL.POCO;
using Y_HELPERS;
using Y_SERVICE.Common;
using Y_SERVICE.Schema;
using Y_SERVICE.Service;

namespace Y_API.Controllers
{
    public class CustomerController : BaseApiController
    {
        [HttpGet]
        public CustomersResponse GetAll()
        {
            try
            {
                return new CustomerService().GetAll();
            }
            catch (Exception ex)
            {
                return new CustomersResponse()
                {
                    success = false,
                    notification = new Notification() { type = NotificationType.Error, stackTrace = ex.StackTrace, description = ex.Message }
                };
            }
        }

        [HttpGet]
        public CustomerResponse Get(Guid ID)
        {
            try
            {
                return new CustomerService().Get(ID);
            }
            catch (Exception ex)
            {
                return new CustomerResponse()
                {
                    success = false,
                    notification = new Notification() { type = NotificationType.Error, stackTrace = ex.StackTrace, description = ex.Message }
                };
            }
        }

        [HttpPost]
        public CustomerResponse Insert(Customer customer)
        {
            try
            {
                return new CustomerService().Insert(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse()
                {
                    success = false,
                    notification = new Notification() { type = NotificationType.Error, stackTrace = ex.StackTrace, description = ex.Message }
                };
            }
        }

        [HttpPost]
        public CustomerResponse Update(Customer customer)
        {
            try
            {
                return new CustomerService().Update(customer);
            }
            catch (Exception ex)
            {
                return new CustomerResponse()
                {
                    success = false,
                    notification = new Notification() { type = NotificationType.Error, stackTrace = ex.StackTrace, description = ex.Message }
                };
            }
        }

        [HttpGet]
        public CustomerResponse Delete(Guid ID)
        {
            try
            {
                return new CustomerService().Delete(ID);
            }
            catch (Exception ex)
            {
                return new CustomerResponse()
                {
                    success = false,
                    notification = new Notification() { type = NotificationType.Error, stackTrace = ex.StackTrace, description = ex.Message }
                };
            }
        }
    }
}
