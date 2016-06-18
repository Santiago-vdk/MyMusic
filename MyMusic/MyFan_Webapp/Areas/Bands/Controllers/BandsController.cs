using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Areas.Bands.Requests;
using MyFan_Webapp.Logic;
using MyFan_Webapp.Models;
using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands.Controllers
{
    public class BandsController : Controller
    {
        // GET: Bands/Bands
        public async Task<ActionResult> Index(int userId)
        {
            if (Sessions.isAuthenticated(Request, Session))
            {
                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (!Sessions.isBand(sessionRol))
                {
                    return View("~/Views/Login/Index.cshtml");
                }
            }
       

            BandProfileViewModel profile = new BandProfileViewModel();
            
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
   

            return View(profile);

        }



        public new async Task<ActionResult> Profile(int userId)
        {
            System.Diagnostics.Debug.WriteLine("check profile from " + userId);

            string response = await clsBandRequests.GetBandInfo(userId);
            string response2 = await clsBandRequests.getBandAlbums(userId);
            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }
            
            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            profile.Info = DataParser.parseBandInfo(response);

            profile.Albums = DataParser.parseAlbums(response2);
            return View(profile);


        }

        public async Task<ActionResult> Edit(int userId)
        {
            string response = await clsBandRequests.GetBandInfo(userId);
            //Hubo error
            if (!ErrorParser.parse(response).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }
            System.Diagnostics.Debug.WriteLine(response);
            string response2 = await clsRegisterRequests.GetRegisterBandForm();
            string ParsedMessage = ErrorParser.parse(response2);

            string response3 = await clsBandRequests.getBandAlbums(userId);

            
            BandProfileViewModel profile = new BandProfileViewModel();
            profile.Id = Int32.Parse(Session["Id"].ToString());
            profile.Username = Session["Username"].ToString();
            profile.Name = Session["Name"].ToString();
            profile.Info = DataParser.parseBandInfo(response);
            profile.EditForm = DataParser.parseBandForm(response2);
            profile.Albums = DataParser.parseAlbums(response3);
            return View(profile);
        }



        [HttpPost]
        public async Task<ActionResult> UpdateProfile(string inputName, string inputDateCreation, string inputHashtag, 
            int selectCountry, List<int> selectGenres, List<string> inputMembers, string inputBiography,  string profilePicture)
        {

            if (Sessions.isAuthenticated(Request, Session))
            {

                PostRegisterBandForm form = new PostRegisterBandForm();
                form.Name = inputName;
                form.DateCreation = inputDateCreation;
                form.Hashtag = inputHashtag;
                form.Country = selectCountry;
                form.Genres = selectGenres;
                form.Members = inputMembers;
                form.Biography = inputBiography;
                form.Picture = profilePicture;

                string response = await clsBandRequests.UpdateProfile((int)Session["Id"], form);
                System.Diagnostics.Debug.WriteLine("form posted", response);
                string ParsedMessage = ErrorParser.parse(response);
                if (!ParsedMessage.Equals(""))
                {
                    ViewBag.Message = ParsedMessage;

                }

                Session["Name"] = form.Name;
                return RedirectToAction("Edit", "Bands", new { area = "Bands", userId = Session["id"] });
            }
            else
            {
                return View("~/Views/Login/Index.cshtml");
            }

        }
    }
}