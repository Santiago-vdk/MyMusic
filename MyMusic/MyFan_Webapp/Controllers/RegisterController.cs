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
            form = DataParser.parseFanForm(form, response);
            
            ViewBag.Message = "";
            ViewBag.AvailableMusicalGenres = form.genres;
            ViewBag.Genders = form.genders;

            PostRegisterFanForm model = new PostRegisterFanForm();
          //  model.Genres = form.genres;
          //  model.Gender = form.genders;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFan(PostRegisterFanForm form)
        {
            System.Diagnostics.Debug.WriteLine(form.Username);

            /* 
             * string inputUsername, string inputPassword,string inputConfirmPassword,
             string inputName, string inputBirthday, string selectGenre, string selectCountry, List<string> selectMusicalGenres
             * 
             * 
             * string response = await clsRegisterRequests.PostRegisterFanForm(inputUsername, inputPassword,inputConfirmPassword,
             inputName, inputBirthday, selectGenre, selectCountry, selectMusicalGenres);

             ErrorParser ErrorParser = new ErrorParser();
             string ParsedMessage = ErrorParser.parse(response);
             if (!ParsedMessage.Equals(""))
             {
                 ViewBag.Message = ParsedMessage;
                 return View("~/Views/Login/Index.cshtml");
             }

             ViewBag.Message = "We are glad to have you onboard!";*/

            return View("~/Views/Login/Index.cshtml");
        }

        public ActionResult Band()
        {
            return View();
        }
    }
}