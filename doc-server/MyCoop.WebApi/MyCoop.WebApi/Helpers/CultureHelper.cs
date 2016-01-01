using System;
using System.Globalization;
using System.Threading;
using System.Web;

namespace MyCoop.WebApi.Helpers
{
    public static class CultureHelper
    {
        public static string GetCulture()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[GlobalKeys.Culture];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return GetDefaultCulture();
        }

        public static string GetDefaultCulture()
        {
            var lang = Culture.Eng;
            //if (HttpContext.Current.Request.UserLanguages != null && 
            //    HttpContext.Current.Request.UserLanguages.Length > 0 &&
            //    HttpContext.Current.Request.UserLanguages[0].Contains(Culture.Rus))
            //{
            //    lang = Culture.Rus;
            //}
            return lang;
        }

        public static void SetCulture(string culture)
        {
            HttpContext.Current.Response.Cookies.Remove(culture);
            var cookie = new HttpCookie(GlobalKeys.Culture);
            cookie.HttpOnly = true;
            cookie.Value = culture;
            cookie.Expires = DateTime.Now.AddYears(1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void SetCultureThread()
        {
            var culture = GetCulture();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }

        public static class Culture
        {
            public static readonly string Eng = "en";
        }
    }

}