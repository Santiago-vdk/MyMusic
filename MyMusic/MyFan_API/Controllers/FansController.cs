using DTO;
using MyFan_Webapp.Areas.Fans.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            return new FanControllerCallsRegisterFan(Request);
        }



        [Route("")]
        [HttpGet]
        // api/v1/users/fans?q=form GET
        public IHttpActionResult GetAllFans(string q)
        {
            if (String.Equals(q, "form"))
            {
                return new FanControllerCallsGetForm(Request);
            }
            

            //Endpoint for retrieving all fans
            throw new NotImplementedException();
        }

        [Route("{fanId}"), HttpGet]
        // api/v1/users/fans/1 GET
        public IHttpActionResult Get(int fanId, string q, int offset = 0, int limit = 5)
        {
            if (String.Equals(q, "bands"))
            {
                //return Ok();
                return new FanControllerCallsGetBands(Request, fanId, offset, limit);

            }
            if (String.Equals(q, "posts"))
            {
                return new FanControllerCallsGetPosts(Request, fanId, offset, limit);
            }
            if (String.Equals(q, "all"))
            {
                return new FanControllerCallsGetProfile(Request, fanId);
            }
            //Endpoint for retrieving one fan
            throw new NotImplementedException();


        }




        [Route("{fanId}")]
        [HttpPut]
        // api/v1/users/fans/1 PUT
        public IHttpActionResult UpdateOneFan(int fanId)
        {
            System.Diagnostics.Debug.WriteLine("Updating fan with id " + fanId);
            System.Diagnostics.Debug.WriteLine("with data " + Request.Content.ReadAsStringAsync().Result);
                //return Ok();
                return new FanControllerCallsUpdateProfile(Request, fanId);

            
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
