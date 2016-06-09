using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class LoginController : Controller
    {


       
        // GET: Login
        public ActionResult Index()
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
                        Session["token"] = null;
                        ViewBag.Message = "logged out";
                        return View();
                    }
                    ViewBag.Message = "you just loggued in";
                    return View();

                }
            }
            ViewBag.Message = "You are in";
            return View();
        }

        public async Task<ActionResult> Login(string inputUsername, string inputPassword)
        {
            PostLoginUserForm form = new PostLoginUserForm();
            form.Username = inputUsername;
            form.Password = inputPassword;

            string response = await clsLoginRequests.PostLoginUserForm(form);

            ErrorParser ErrorParser = new ErrorParser();
            string ParsedMessage = ErrorParser.parse(response);
            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }

            DataParser DataParser = new DataParser();
            int id = DataParser.parseUserForm(response);

            string token = Guid.NewGuid().ToString();
            Session["token"] = token;
            Session["username"] = form.Username;
            Session["id"] = id;
            Session.Timeout = 1;

            ViewBag.Message = "good to have you on board";

            return View();
        }
    }
}