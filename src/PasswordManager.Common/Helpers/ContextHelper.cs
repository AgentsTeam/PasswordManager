using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Common.Helpers
{
    public class ContextHelper
    {
        public static string GetItem(string itemName)
        {
            try
            {
                return HttpContextHelper.Current.Items[itemName].ToString();
            }
            catch
            {
                return null;
            }
        }

        public static Guid? GetUserId()
        {
            try
            {
                var claims = HttpContextHelper.Current.User.Claims.ToList();
                var userId = HttpContextHelper.Current.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                return Guid.Parse(userId);
            }
            catch
            {
                return null;
            }
        }
    }
}
