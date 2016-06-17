using DTO;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Logic;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests;
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

            FanProfileViewModel profile = DataParser.parseFanProfile(response);
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            
            return View(profile);
        }



        public new async Task<ActionResult> Profile(int userId)
        {
            System.Diagnostics.Debug.WriteLine(userId);
            string response = await clsFanRequests.GetFanBands(userId);
            string response2 = await clsFanRequests.GetFanInfo(userId);
            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }

            FanProfileViewModel profile = DataParser.parseFanBands(response);

            profile.Info = DataParser.parseFanInfo(response2);

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
            FanProfileViewModel profile = DataParser.parseFanBands(response);

            string response2 = await clsRegisterRequests.GetRegisterFanForm();
            string ParsedMessage = ErrorParser.parse(response2);
            profile.EditForm = DataParser.parseFanForm(response2);

            string response3 = await clsFanRequests.GetFanInfo(userId);

            profile.Info = DataParser.parseFanInfo(response3);

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            return View(profile);

        }

        public async Task<ActionResult> Search(string name, string country, string genre)
        {
            System.Diagnostics.Debug.WriteLine(name);
            System.Diagnostics.Debug.WriteLine(genre);

            string response = await clsFanRequests.GetFanBands(Int32.Parse(Session["Id"].ToString()));
            List<int> l = new List<int>();
            l.Add(0);
            clsSearch searchParams = new clsSearch();
            searchParams.Name = name;
            searchParams.Genres = l;
            searchParams.Country = 0;

            string response2 = await clsUserRequests.Search(searchParams);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }
            FanProfileViewModel profile = DataParser.parseFanBands(response);

            profile.SearchResults = DataParser.parseBands(response2);

            System.Diagnostics.Debug.WriteLine("search " + profile.SearchResults.Count);

            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            //return View(profile);


            //TempData["profile"] = profile;
            //return RedirectToAction("Search", "Fans", new { area = "Fans", userId = Session["id"] });
            return View(profile);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateProfile(string inputName, string inputBirthday, int selectGender, int selectCountry, 
            List<int> selectGenres, string profilePicture)
        {
            System.Diagnostics.Debug.WriteLine(selectGender);
            System.Diagnostics.Debug.WriteLine(selectCountry);
            if (Sessions.isAuthenticated(Request, Session))
            {

                RegisterFanForm form = new RegisterFanForm();
                form.Name = inputName;
                form.Birthday = inputBirthday;
                form.Gender = selectGender;
                form.Country = selectCountry;
                form.Genres = selectGenres;
                form.Picture = profilePicture;

                string response = await clsFanRequests.UpdateProfile((int)Session["Id"], form);
                System.Diagnostics.Debug.WriteLine("form pytted", response);
                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = ParsedMessage;
                    
                }

                Session["Name"] = form.Name;
                return RedirectToAction("Edit", "Fans", new { area = "Fans", userId = Session["id"] });
            } else
            {
                return View("~/Views/Login/Index.cshtml");
            }
            
        }


    }
}