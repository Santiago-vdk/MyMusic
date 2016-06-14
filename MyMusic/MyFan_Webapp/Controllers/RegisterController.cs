using DTO;
using MyFan_Webapp.Logic;
using MyFan_Webapp.Models;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MyFan_Webapp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public async Task<ActionResult> Fan()
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


            string response = await clsRegisterRequests.GetRegisterFanForm();

            string ParsedMessage = ErrorParser.parse(response);

            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return RedirectToAction("Index");
            }
            Form formModel = DataParser.parseFanForm(response);

            return View(formModel);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFan(string inputUsername, string inputPassword, string inputConfirmPassword, 
            string inputName, string inputBirthday, int selectGender, int selectCountry, List<int> selectGenres, string profilePicture)
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
            PostRegisterFanForm form = new PostRegisterFanForm();
            form.Username = inputUsername;
            form.Password = inputPassword;
            form.ConfirmPassword = inputConfirmPassword;
            form.Name = inputName;
            form.Birthday= inputBirthday;
            form.Gender= selectGender;
            form.Country = selectCountry;
            form.Genres = selectGenres;
            form.Picture = profilePicture;

            string response = await clsRegisterRequests.PostRegisterFanForm(form);
            System.Diagnostics.Debug.WriteLine(response);
            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("Index");
            }
            ViewBag.Message = "We are glad to have you onboard!";

            return RedirectToAction("Index","Login");
        }

        [HttpPost]
        public async Task<ActionResult> ValidateUsername(string Username)
        {
            System.Diagnostics.Debug.WriteLine(Username);
            string response = await clsRegisterRequests.ValidateUsername(Username);

            string ParsedMessage = ErrorParser.parse(response);

            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                System.Diagnostics.Debug.WriteLine("Already exists");
                return Json(true);
                
            }
            else
            {
                return Json(false);
            }

        }


        public async Task<ActionResult> Band()
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
            string response = await clsRegisterRequests.GetRegisterBandForm();

            string ParsedMessage = ErrorParser.parse(response);
            
            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return RedirectToAction("Index");
            }

            Form form = DataParser.parseBandForm(response);

            return View(form);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterBand(string inputUsername, string inputPassword, string inputConfirmPassword,
            string inputName, string inputHashtag, string inputDateCreation, int selectCountry, List<int> selectGenres, 
            List<string> inputMembers, string inputBiography, string profilePicture)
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
            PostRegisterBandForm form = new PostRegisterBandForm();
            form.Username = inputUsername;
            form.Password = inputPassword;
            form.ConfirmPassword = inputConfirmPassword;
            form.Name = inputName;
            form.Hashtag = inputHashtag;
            form.DateCreation = inputDateCreation;
            form.Country = selectCountry;
            form.Genres = selectGenres;
            form.Members = inputMembers;
            form.Biography = inputBiography;
            form.Picture = profilePicture;

            string response = await clsRegisterRequests.PostRegisterBandForm(form);

            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return RedirectToAction("Index");
            }
            ViewBag.Message = "We are glad to have you onboard!";

            return RedirectToAction("Index", "Login");
        }
    }
}