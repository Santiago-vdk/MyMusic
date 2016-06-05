using MyFan_Webapp.Requests.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public async Task<ActionResult> Fan()
        {
            FanForm form = await clsRegisterRequests.GetRegisterFanForm();
            ViewBag.AvailableMusicalGenres = form.MusicalGenres;


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterFan(string inputUsername, string inputPassword, string inputConfirmPassword,
            string inputName, string inputBirthday, string selectGenre, string selectCountry, string[] selectMusicalGenres,
            string accept)
        {
            System.Diagnostics.Debug.WriteLine(inputUsername);
            System.Diagnostics.Debug.WriteLine(inputPassword);
            System.Diagnostics.Debug.WriteLine(inputConfirmPassword);
            System.Diagnostics.Debug.WriteLine(inputName);
            System.Diagnostics.Debug.WriteLine(inputBirthday);
            System.Diagnostics.Debug.WriteLine(selectGenre);
            System.Diagnostics.Debug.WriteLine(selectCountry);
            System.Diagnostics.Debug.WriteLine(selectMusicalGenres[0]);
            System.Diagnostics.Debug.WriteLine(selectMusicalGenres[1]);
            System.Diagnostics.Debug.WriteLine(selectMusicalGenres[2]);
            System.Diagnostics.Debug.WriteLine(selectMusicalGenres[3]);
            System.Diagnostics.Debug.WriteLine(selectMusicalGenres[4]);
            System.Diagnostics.Debug.WriteLine(accept);

            /*await clsRegisterRequests.RegisterRequest(inputUsername, inputPassword, inputConfirmPassword,
            inputName, inputBirthday, selectGenre, selectCountry, selectMusicalGenres,
            accept);*/

            return Redirect("/");
        }

        public ActionResult Band()
        {
            return View();
        }
    }
}