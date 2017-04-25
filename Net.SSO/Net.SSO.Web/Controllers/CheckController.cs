using Net.SSO.Server.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Net.SSO.Web.Controllers
{
    public class CheckController : ApiController
    {
        [HttpGet]
        public object CheckTicket(string ticket)
        {
            return new {State=1,IsExists= CacheHelper.GetCache(ticket) != null };
        }
    }
}
