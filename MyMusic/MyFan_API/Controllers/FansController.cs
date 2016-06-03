using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/fans")]
    public class FansController : ApiController
    {
        [Route("")]
        [HttpPost]
        // api/v1/users/fans POST
        public IHttpActionResult CreateFan()
        {
            //Endpoint for creating a new fan user
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        // api/v1/users/fans GET
        public IHttpActionResult GetAllFans()
        {
 

            //Endpoint for retrieving all fans
            throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpGet]
        // api/v1/users/fans/1 GET
        public HttpResponseMessage GetOneFan(int fanId)
        {
            System.Diagnostics.Debug.WriteLine("request for fan with id " + fanId);
            String r = "Showing albums from band " + fanId;

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Json(new { response = r }));
            return response;

            //Endpoint for retrieving one fan
            //throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpPut]
        // api/v1/users/fans/1 PUT
        public IHttpActionResult UpdateOneFan(int fanId)
        {
            //Endpoint for updating one fan
            throw new NotImplementedException();
        }

        [Route("{fanId}")]
        [HttpDelete]
        // api/v1/users/fans/1 DELETE
        public IHttpActionResult DeleteOneFan(int fanId)
        {
            //Endpoint for deleting one fan
            throw new NotImplementedException();
        }

    }
}
