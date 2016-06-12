using DTO;
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

            const string FileTypePrefixJpg = "data:image/jpg;base64,";
            const string FileTypePrefixPng = "data:image/png;base64,";
            const string FileTypePrefixGif = "data:image/gif;base64,";

            if (profilePicture.Contains(FileTypePrefixJpg))
            {
                string c = profilePicture.Substring(FileTypePrefixJpg.Length);
                byte[] imageBytes = Convert.FromBase64String(c);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                image.Save(@"c:\i1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            if (profilePicture.Contains(FileTypePrefixPng))
            {
                string c = profilePicture.Substring(FileTypePrefixPng.Length);
                byte[] imageBytes = Convert.FromBase64String(c);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                image.Save(@"c:\i1.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            if (profilePicture.Contains(FileTypePrefixGif))
            {
                string c = profilePicture.Substring(FileTypePrefixGif.Length);
                byte[] imageBytes = Convert.FromBase64String(c);
                MemoryStream ms = new MemoryStream(imageBytes, 0,
                  imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                image.Save(@"c:\i1.gif", System.Drawing.Imaging.ImageFormat.Gif);
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



        public async Task<ActionResult> Band()
        {
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
            List<string> inputMembers, string inputBiography)
        {
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

            string response = await clsRegisterRequests.PostRegisterBandForm(form);

            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return RedirectToAction("Index");
            }
            ViewBag.Message = "We are glad to have you onboard!";
            return RedirectToAction("Index");
        }
    }
}