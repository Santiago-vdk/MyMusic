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
            try
            {
                profile.Id = Int32.Parse(Session["Id"].ToString());
                profile.Username = Session["Username"].ToString();
                profile.Name = Session["Name"].ToString();
            }
            catch (NullReferenceException)
            {
                //Not logged in
                ViewBag.Message = "Please log in first";
                return View("~/Views/Login/Index.cshtml");
            }
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

            try { 
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            }
            catch (NullReferenceException)
            {
                //Not logged in
                ViewBag.Message = "Please log in first";
                return View("~/Views/Login/Index.cshtml");
            }
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

            try { 
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            }
            catch (NullReferenceException)
            {
                //Not logged in
                ViewBag.Message = "Please log in first";
                return View("~/Views/Login/Index.cshtml");
            }
            return View(profile);

        }

        public async Task<ActionResult> Search(string name, string country, string genre)
        {
            string response = await clsFanRequests.GetFanBands(Int32.Parse(Session["Id"].ToString()));
            clsSearch searchParams = new clsSearch();
            searchParams.Name = name;
            searchParams.Genre = genre;
            searchParams.Country = country;

            string response2 = await clsUserRequests.Search(searchParams);

            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life2...";
            }
            FanProfileViewModel profile = DataParser.parseFanBands(response);

            profile.SearchResults = DataParser.parseBands(response2);

            System.Diagnostics.Debug.WriteLine("search " + profile.SearchResults.Count);

            try { 
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            }
            catch (NullReferenceException)
            {
                //Not logged in
                ViewBag.Message = "Please log in first";
                return View("~/Views/Login/Index.cshtml");
            }
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
                try { 
                Session["Name"] = form.Name;
                }
                catch (NullReferenceException)
                {
                    //Not logged in
                    ViewBag.Message = "Please log in first";
                    return View("~/Views/Login/Index.cshtml");
                }
                return RedirectToAction("Edit", "Fans", new { area = "Fans", userId = Session["id"] });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }

        }



        public async Task<ActionResult> followBand(int fanId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " is going to follow " + bandId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await clsFanRequests.FollowBand(fanId, bandId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json(new { state = false });
                }

                return Json(new { state = true });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }

        public async Task<ActionResult> unfollowBand(int fanId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " unfollwing " + bandId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await clsFanRequests.UnFollowBand(fanId, bandId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json(new { state = false });
                }

                return Json(new { state = true });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }

        public async Task<ActionResult> isFollowingBand(int fanId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + "follows? " + bandId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await clsFanRequests.isFollowingBand(fanId, bandId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                }

                return Json(new { state = DataParser.parseResponse(response).Data });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }

        public async Task<ActionResult> GetBandStats(int fanId, int bandId)
        {
            System.Diagnostics.Debug.WriteLine(fanId + " get stats " + bandId);
            if (Sessions.isAuthenticated(Request, Session))
            {
                string response = await clsFanRequests.GetBandStats(fanId, bandId);
                System.Diagnostics.Debug.WriteLine(response);

                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = "Something went wrong";
                    return Json("");
                }

                string j = DataParser.parseResponse(response).Data;
                System.Diagnostics.Debug.WriteLine(j);
                return Json(j);
               // return Json(new { Followers = 1200000, Calification = 5 });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }
        }
    }
}