using Y_SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Y_API
{
    public class ApiAuthenticationFilter : GenericAuthenticationFilter
    {
        public ApiAuthenticationFilter()
        {
        }

        public ApiAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var provider = new UserService();
            if (provider != null)
            {
                var userResponse = provider.Authenticate(username, password);
                if (userResponse != null)
                {
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                        basicAuthenticationIdentity.UserId = userResponse.User.ID;
                    return true;
                }
            }
            return false;
        }
    }
}
