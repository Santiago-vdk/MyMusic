using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Logic
{
    public static class Sessions
    {
        public static bool isAuthenticated(HttpRequestBase request, HttpSessionStateBase session)
        {
            if (session["token"] != null)
            {
                if (session.IsNewSession)
                {
                    string CookieHeaders = request.Headers["Cookie"];

                    if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        //logged out
                        session["token"] = null;
                        return false;

                    }
                    //you just loggued in
                    //return View();
                    return false;
                }
                return true;
            }
            return false;
        }

        public static bool isBand(int pIntUserRol)
        {
            // rol = 1 (banda), rol = 2 (fanatico)
            if (pIntUserRol == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool isFan(int pIntUserRol)
        {
            // rol = 1 (banda), rol = 2 (fanatico)
            if (pIntUserRol == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}