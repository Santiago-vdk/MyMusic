using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BCrypt.Net;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        [Route("users"), HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            //System.Diagnostics.Debug.WriteLine(uniqueCode());
            //return Json(new { response = "r" });

            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

        private void register(string v)
        {
            string hashedForSending = BCrypt.Net.BCrypt.HashPassword(v);
            System.Diagnostics.Debug.WriteLine("Hash when sended " + hashedForSending);
            //Generate salt for user
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt(13);
            System.Diagnostics.Debug.WriteLine("unique salt for user " + mySalt);
            //Rehash password
            string password = BCrypt.Net.BCrypt.HashPassword(hashedForSending, mySalt);
            System.Diagnostics.Debug.WriteLine("Final password " + password);
            System.Diagnostics.Debug.WriteLine("\n");
        }
    }
}
