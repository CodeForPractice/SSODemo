using System;
using System.Web;

namespace Net.SSO.Server.Infrastructure
{
    public class CookieHelper
    {
        public static void SetCookie(string key, string value)
        {
            if (HttpContext.Current != null)
            {
                HttpCookie cookie = new HttpCookie(key, value);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static object GetCookie(string key)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request.Cookies[key] != null)
            {
                return HttpContext.Current.Request.Cookies[key].Value;
            }
            return null;
        }

        public static void RemoveCookie(string key)
        {
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Response.Cookies[key] != null)
                {
                    HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }
    }
}