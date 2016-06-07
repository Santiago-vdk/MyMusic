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

            GetRegisterFanForm form = new GetRegisterFanForm();
            ErrorParser ErrorParser = new ErrorParser();
            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                //Hubo error
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }

            DataParser DataParser = new DataParser();
            System.Diagnostics.Debug.WriteLine(response);
            form = DataParser.parseFanForm(form, response);

            ViewBag.Message = "";
            ViewBag.AvailableMusicalGenres = form.genres;
            ViewBag.Genders = form.genders;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFan(string inputUsername, string inputPassword, string inputName, 
            string inputBirthday, string selectGenre, string selectCountry, string[] selectMusicalGenres)
        {
            /* System.Diagnostics.Debug.WriteLine(inputUsername);
             System.Diagnostics.Debug.WriteLine(inputPassword);
             System.Diagnostics.Debug.WriteLine(inputName);
             System.Diagnostics.Debug.WriteLine(inputBirthday);
             System.Diagnostics.Debug.WriteLine(selectGenre);
             System.Diagnostics.Debug.WriteLine(selectCountry);
             System.Diagnostics.Debug.WriteLine(selectMusicalGenres[0]);
             System.Diagnostics.Debug.WriteLine(selectMusicalGenres[1]);
             System.Diagnostics.Debug.WriteLine(selectMusicalGenres[2]);
             System.Diagnostics.Debug.WriteLine(selectMusicalGenres[3]);
             System.Diagnostics.Debug.WriteLine(selectMusicalGenres[4]);*/


            string response = await clsRegisterRequests.PostRegisterFanForm(inputUsername, inputPassword,
            inputName, inputBirthday, selectGenre, selectCountry, selectMusicalGenres);
            
            ErrorParser ErrorParser = new ErrorParser();
            string ParsedMessage = ErrorParser.parse(response);
            if (!ParsedMessage.Equals(""))
            {
                ViewBag.Message = ParsedMessage;
                return View("~/Views/Login/Index.cshtml");
            }

            ViewBag.Message = "We are glad to have you onboard!";

            return View("~/Views/Login/Index.cshtml");
        }

        public ActionResult Band()
        {
            return View();
        }
    }
}