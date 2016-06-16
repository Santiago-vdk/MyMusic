using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Logic;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class FansController : Controller
    {
        public async Task<ActionResult> Index(int userId)
        {
            if (Sessions.isAuthenticated(Request, Session))
            {
                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (!Sessions.isFan(sessionRol))
                {
                    return View("~/Views/Login/Index.cshtml");
                }
            }
            //[Bandas,Posts]
            List<string> response = await clsFanRequests.GetFanProfile(userId);
      
            //Hubo error
            if (!ErrorParser.parse(response[0]).Equals("") || !ErrorParser.parse(response[1]).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            VMFanProfile profile = DataParser.parseFanProfile(response);
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            
            return View(profile);
        }



        public new async Task<ActionResult> Profile(int userId)
        {
            System.Diagnostics.Debug.WriteLine(userId);
            string response = await clsFanRequests.GetFanBands(userId);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }

            VMFanProfile profile = DataParser.parseFanBands(response);

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            return View(profile);


        }

        public async Task<ActionResult> Edit(int userId)
        {
            string response = await clsFanRequests.GetFanBands(userId);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }
            VMFanProfile profile = DataParser.parseFanBands(response);

            string response2 = await clsRegisterRequests.GetRegisterFanForm();
            string ParsedMessage = ErrorParser.parse(response2);
            profile.EditForm = DataParser.parseFanForm(response2);

            

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            return View(profile);
        }

    }
}