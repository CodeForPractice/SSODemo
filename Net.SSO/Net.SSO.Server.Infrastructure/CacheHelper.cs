using System;

namespace Net.SSO.Server.Infrastructure
{
    public class CacheHelper
    {
        public static void AddCache(string key, object value, TimeSpan span)
        {
            if (string.IsNullOrWhiteSpace(key) || value == null)
            {
                return;
            }
            System.Web.HttpRuntime.Cache.Insert(key, value, null, System.Web.Caching.Cache.NoAbsoluteExpiration, span);
        }

        public static object GetCache(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }
            if (System.Web.HttpRuntime.Cache[key] != null)
            {
                return System.Web.HttpRuntime.Cache[key];
            }
            return null;
        }

        public static void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return;
            }
            System.Web.HttpRuntime.Cache.Remove(key);
        }
    }
}