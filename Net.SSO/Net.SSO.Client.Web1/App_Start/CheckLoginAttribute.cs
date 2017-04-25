using Net.SSO.Server.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net.SSO.Client.Web1.App_Start
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string needCheckedTicket = string.Empty;
            if (filterContext.HttpContext.Request["ticket"] != null)
            {
                needCheckedTicket = filterContext.HttpContext.Request["ticket"];
            }
            else if (CookieHelper.GetCookie("WEB1_TICKET") != null)
            {
                needCheckedTicket = CookieHelper.GetCookie("WEB1_TICKET").ToString();
            }
            if (string.IsNullOrWhiteSpace(needCheckedTicket))
            {
                filterContext.Result = new RedirectResult("http://localhost:2216/Account/Login?backUrl=" + filterContext.HttpContext.Request.Url);
            }
            else
            {
                string result = HttpHelper.Get("http://localhost:2216/api/Check/CheckTicket?ticket=" + needCheckedTicket);
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(result);
                if (obj.IsExists != null && obj.IsExists == true)
                {
                    if (CookieHelper.GetCookie("WEB1_TICKET") == null)
                        CookieHelper.SetCookie("WEB1_TICKET", needCheckedTicket);
                }
                else
                {
                    filterContext.Result = new RedirectResult("http://localhost:2216/Account/Login?backUrl=" + filterContext.HttpContext.Request.Url);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}