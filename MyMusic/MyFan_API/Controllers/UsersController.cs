using System;
using System.Web.Http;
using MyFan_API.ControllerCalls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        [Route("users"), HttpGet]
        public IHttpActionResult GetUsers(string q, string action, string value)
        {
            if(String.Equals(q.ToLower(), "username") && String.Equals(action.ToLower(), "validate") && (value.ToLower() != null))
            {
                return new UserControllerCallsValidateUsername(Request, value);
            }
            if (String.Equals(q.ToLower(), "image") && String.Equals(action.ToLower(), "profile") && (value.ToLower() != null))
            {
                return new UserControllerCallsGetProfilePicture(Request, value);
            }
            if (String.Equals(q.ToLower(), "image") && String.Equals(action.ToLower(), "album") && (value.ToLower() != null))
            {
                return new UserControllerCallsGetDiskPicture(Request, value);
            }
            throw new NotImplementedException();
        }

        

        [Route("users/login"), HttpPost]
        public IHttpActionResult Login()
        {
            return new UserControllerCallsLoginUser(Request);

            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

        [Route("users/search"), HttpPost]
        public IHttpActionResult Search(int offset = 0, int limit = 5)
        {

            return new UserControllerCallsSearch(Request, offset, limit);

            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

    }
}
