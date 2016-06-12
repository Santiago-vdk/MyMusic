using DTO;
using MyFan_Webapp.Models;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Requests.Register;
using System.Collections.Generic;
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
                return View("~/Views/Login/Index.cshtml");
            }
            Form formModel = DataParser.parseFanForm(response);

            return View(formModel);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFan(string inputUsername, string inputPassword, string inputConfirmPassword, 
            string inputName, string inputBirthday, int selectGender, int selectCountry, List<int> selectGenres)
        {
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
                return View("~/Views/Login/Index.cshtml");
            }
            ViewBag.Message = "We are glad to have you onboard!";
            return View("~/Views/Login/Index.cshtml");
        }



        public async Task<ActionResult> Band()
        {
            string response = await clsRegisterRequests.GetRegisterBandForm();

            string ParsedMessage = ErrorParser.parse(response);
            
            //Hubo error
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }

            Form form = DataParser.parseBandForm(response);

            return View(form);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterBand(string inputUsername, string inputPassword, string inputConfirmPassword,
            string inputName, string inputHashtag, string inputDateCreation, int selectCountry, List<int> selectGenres,
            string inputBiography)
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
            form.Biography = inputBiography;

            string response = await clsRegisterRequests.PostRegisterBandForm(form);

            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }
            ViewBag.Message = "We are glad to have you onboard!";
            return View("~/Views/Login/Index.cshtml");
        }
    }
}