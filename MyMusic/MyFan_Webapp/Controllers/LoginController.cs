using MyFan_Webapp.Logic;
using MyFan_Webapp.Models.Views;
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
            if (Sessions.isAuthenticated(Request, Session))
            {

                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (Sessions.isBand(sessionRol))
                {
                    return RedirectToAction("Index", "Bands", new { area = "Bands", userId = Session["id"] });
                }
                else if (Sessions.isFan(sessionRol))
                {
                    return RedirectToAction("Index", "Fans", new { area = "Fans", userId = Session["id"] });
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ViewBag.Message = "";
                return View();
            }
        }

        public async Task<ActionResult> Login(string inputUsername, string inputPassword)
        {
            if (Sessions.isAuthenticated(Request, Session))
            {
                return RedirectToAction("Index", "Fans", new { area = "Fans", userId = Session["id"] });
            }
            PostLoginUserForm form = new PostLoginUserForm();
            form.Username = inputUsername;
            form.Password = inputPassword;

            string response = await clsLoginRequests.PostLoginUserForm(form);

            System.Diagnostics.Debug.WriteLine(response);
  
            string ParsedMessage = ErrorParser.parse(response);
            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }
            UserSession session = DataParser.parseUserForm(response);

            string token = Guid.NewGuid().ToString();
            Session["token"] = token;
            Session["username"] = session.Username;
            Session["id"] = session.Id;
            Session["rol"] = session.Rol;
            Session.Timeout = 10;


       

            if (Sessions.isBand(session.Rol))
            {
                return RedirectToAction("Index", "Bands", new { area = "Bands", userId = session.Id });
            }
            else if(Sessions.isFan(session.Rol))
            {
                return RedirectToAction("Index", "Fans", new { area = "Fans", userId = session.Id });
            }
            else {
                return HttpNotFound();
            }
            
        }
    }
}