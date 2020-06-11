using Y_SERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Y_SERVICE.Schema;
using System.Configuration;
using Y_HELPERS;

namespace Y_API.Controllers
{
    public class AuthenticateController : ApiController
    {
        TokenService _TokenService = new TokenService();

        [ApiAuthenticationFilter]
        public TokenResponse GetAccessToken()
        {
            try
            {
                if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                    {
                        var userID = basicAuthenticationIdentity.UserId;
                        var token = _TokenService.GenerateToken(userID);
                        return new TokenResponse()
                        {
                            success = true,
                            Token = token.AuthToken,
                            TokenExpiry = ConfigurationManager.AppSettings["AuthTokenExpiry"]

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new TokenResponse()
                {
                    success = false,
                    notification = ExceptionHelper.CreateBaseErrors(ex)
                };
            }
            return null;
        }
    }
}
