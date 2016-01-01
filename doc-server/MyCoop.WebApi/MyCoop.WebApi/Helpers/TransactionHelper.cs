using System;
using System.Web;

namespace MyCoop.WebApi.Helpers
{
    public static class TransactionHelper
    {
        public static Guid GetId()
        {
            if (HttpContext.Current.Items[GlobalKeys.TransactionId] != null)
            {
                return (Guid)HttpContext.Current.Items[GlobalKeys.TransactionId];
            }
            var id = Guid.NewGuid();
            HttpContext.Current.Items[GlobalKeys.TransactionId] = id;
            return id;
        }
    }
}