using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class LogoutController : Controller
    {
        // GET: Logout
        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Logout");
            if (Session["token"] != null)
            {
                if (Session.IsNewSession)
                {
                    string CookieHeaders = Request.Headers["Cookie"];

                    if ((null != CookieHeaders) && (CookieHeaders.IndexOf("ASP.NET_SessionId") >= 0))
                    {
                        //logged out
                        Session["token"] = null;
                        Session.Abandon();
                        Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
                        return View("~/Views/Login/Index.cshtml");

                    }
                    //you just loggued in
                    //return View();
                    Session["token"] = null;
                    Session.Abandon();
                    Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
                    return View("~/Views/Login/Index.cshtml");
                }
                Session["token"] = null;
                Session.Abandon();
                Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
                return View("~/Views/Login/Index.cshtml");
            }
            Session["token"] = null;
            Session.Abandon();
            Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
            return View("~/Views/Login/Index.cshtml");
        }
    }
}