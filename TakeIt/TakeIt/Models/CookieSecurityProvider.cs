using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace TakeIt.Models
{
    static class CookieSecurityProvider
    {
        private static MethodInfo _encode;
        private static MethodInfo _decode;
        // CookieProtection.All enables 'temper proffing' and 'encryption' for cookie
        private static CookieProtection _cookieProtection = CookieProtection.All;

        //Static constructor to get reference of Encode and Decode methods of Class CookieProtectionHelper
        //using Reflection.
        static CookieSecurityProvider()
        {
        }

        public static HttpCookie Encrypt(HttpCookie httpCookie)
        {
            byte[] buffer = Encoding.Default.GetBytes(httpCookie.Value);
            httpCookie.Value = (string)MachineKey.Encode(buffer, MachineKeyProtection.All);

            return httpCookie;
        }
        public static HttpCookie Decrypt(HttpCookie httpCookie)
        {
            byte[] buffer = (byte[])MachineKey.Decode(httpCookie.Value, MachineKeyProtection.All);
            httpCookie.Value = Encoding.Default.GetString(buffer, 0, buffer.Length);
            return httpCookie;
        }

    }
}
