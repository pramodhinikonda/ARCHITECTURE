using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Y_SERVICE;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace Y_API.ActionFilters
{
    public class AuthorizationRequiredAttribute : ActionFilterAttribute
    {
        private const string Token = "Token";
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            if (SkipAuthorization(filterContext))
                return;

            var tService = new TokenService();

            if (filterContext.Request.Headers.Contains(Token))
            {
                var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

                if (!tService.ValidateToken(tokenValue))
                {
                    var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
                    filterContext.Response = responseMessage;
                }
            }
            else
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);

            base.OnActionExecuting(filterContext);

        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            if (!Enumerable.Any(actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>()))
                return Enumerable.Any(actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>());
            else
                return true;
        }
    }
}
