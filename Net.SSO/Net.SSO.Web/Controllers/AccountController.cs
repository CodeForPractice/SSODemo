using Net.SSO.Server.Infrastructure;
using Net.SSO.Web.App_Start;
using Net.SSO.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net.SSO.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [Login]
        [HttpGet]
        public ActionResult Login(string appKey,string backUrl)
        {
            return View(new LoginModel(backUrl));
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "yjq" && model.Pwd == "123456")
                {
                    string ticket=CrypHelper.GetNonce();
                    CookieHelper.SetCookie("SSO_Ticket", ticket);
                    CacheHelper.AddCache(ticket, 1, TimeSpan.FromHours(5));
                    if (string.IsNullOrWhiteSpace(model.BackUrl))
                    {
                        model.BackUrl = "/Home/Index";
                    }
                    if (model.BackUrl.IndexOf('?') > 0)
                    {
                        model.BackUrl += "&ticket=" + ticket;
                    }
                    else
                    {
                        model.BackUrl += "?ticket=" + ticket;
                    }
                    return Redirect(model.BackUrl);
                }
            }
            return View(model);
        }
    }
}