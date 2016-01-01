using System;
using System.Web.Script.Serialization;

namespace MyCoop.WebApi.Extentions
{
    public static class JsonExtentions
    {
        public static string ToJson<T>(this T obj) where T : class 
        {
            if (obj == null)
            {
                return String.Empty;
            }
            var js = new JavaScriptSerializer();
            return js.Serialize(obj);
        }
    }
}