using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class LoginController : Controller
    {

         private bool isExpired()
        {
            if (Session["token"] != null)
            {
                if (Session.IsNewSession)
                {
                    string CookieHeaders = Request.Headers["Cookie"];

                    if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        // IsNewSession is true, but session cookie exists,
                        // so, ASP.NET session is expired
                        return true;
                    }
                }
            }

            // Session is not expired and function will return false,
            // could be new session, or existing active session
            return false;
        }

       
        // GET: Login
        public ActionResult Index()
        {
          
            if (isExpired())
            {
                ViewBag.Message = "Your session expired ";

                string token = Guid.NewGuid().ToString();
                Session["token"] = token;
                Session["username"] = "shagy";
                Session["id"] = 532563;
                Session.Timeout = 1;
                
                ViewBag.Message = "Here is a new session " + Session["username"] + ":" + token;
                return View();
            }
            else
            {
                ViewBag.Message = "Session active " + Session["username"] + ":" + Session["token"];
                return View();
            }


           /* if (Session["token"] == null)
            {
                string token = Guid.NewGuid().ToString();
                Session["token"] = token;
                Session["username"] = "shagy";
                Session["id"] = 532563;
                Session.Timeout = 1;
                System.Diagnostics.Debug.WriteLine("created session");
                ViewBag.Message = "created session with value " + token;
                return View();
            }
            else if (Session.Timeout == 0) {
                ViewBag.Message = "Your session expired ";
                Session["username"] 
                return View();
            }



            ViewBag.Message = "you already have a session, " + Session["username"] + ":" + Session["id"];
            return View();*/
        }
    }
}