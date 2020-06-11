using Y_API.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Y_API.Controllers
{
    [AuthorizationRequired]
    public class BaseApiController : ApiController
    {
    }
}
