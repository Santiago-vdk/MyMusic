using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        [Route("users")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }
    }


}
