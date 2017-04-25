using Net.SSO.Server.Infrastructure;
using Net.SSO.Server.Repository;
using System.Web.Mvc;

namespace Net.SSO.Web.App_Start
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.Cookies["SSO_Ticket"] != null)
            {
                if (CacheHelper.GetCache(filterContext.RequestContext.HttpContext.Request.Cookies["SSO_Ticket"].Value) != null)
                {
                    var backUrl = filterContext.RequestContext.HttpContext.Request["backUrl"];
                    if (backUrl != null)
                    {
                        EnhancedUriBuilder uriBuilder = new EnhancedUriBuilder(backUrl);
                        uriBuilder.QueryItems["ticket"] = CookieHelper.GetCookie("SSO_Ticket").ToString();
                        backUrl = uriBuilder.Uri.ToString();
                    }
                    else
                    {
                        backUrl = "/Home/Index";
                    }
                    filterContext.Result = new RedirectResult(backUrl);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}