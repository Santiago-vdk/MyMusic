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
            if (String.Equals(q, "search_values"))
            {
                return new FanControllerCallsGetSearchParams(Request);
            }


            //Endpoint for retrieving all fans
            throw new NotImplementedException();
        }

        [Route("{fanId}"), HttpGet]
        // api/v1/users/fans/1 GET
        public IHttpActionResult Get(int fanId, string q, int offset = 0, int limit = 5, string value = "")
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
            if(String.Equals(q, "isfollowing") && !String.Equals(value, ""))
            {
                return new FanControllerCallsIsFollowing(Request, fanId, Int32.Parse(value));
            }
            //Endpoint for retrieving one fan
            throw new NotImplementedException();


        }




        [Route("{fanId}")]
        [HttpPut]
        // api/v1/users/fans/1 PUT
        public IHttpActionResult UpdateOneFan(int fanId, string action, string value = "")
        {
            //System.Diagnostics.Debug.WriteLine("Updating fan with id " + fanId);
           // System.Diagnostics.Debug.WriteLine("with data " + Request.Content.ReadAsStringAsync().Result);
            if(String.Equals(action, "follow"))
            {
                return new FanControllerCallsFollowBand(Request, fanId, Int32.Parse(value));
            }
            if (String.Equals(action, "unfollow"))
            {
                return new FanControllerCallsUnFollowBand(Request, fanId, Int32.Parse(value));
            }
            if (String.Equals(action, "update"))
            {
                return new FanControllerCallsUpdateProfile(Request, fanId);
            }

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
