using System;
using System.Web.Http;
using MyFan_API.ControllerCalls;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        [Route("users"), HttpGet]
        public IHttpActionResult GetUsers(string q, string action, string value)
        {
            if(String.Equals(q, "username") && String.Equals(action, "validate") && value != null)
            {
                return new UserControllerCallsValidateUsername(Request, value);
            }
            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

        [Route("users/login"), HttpPost]
        public IHttpActionResult Login()
        {
            return new UserControllerCallsLoginUser(Request);

            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

      /*  private void register(string v)
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
        }*/
    }
}
