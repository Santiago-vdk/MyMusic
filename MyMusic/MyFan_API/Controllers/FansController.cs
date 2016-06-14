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
        public IHttpActionResult Get(int fanId, string q, int offset=0, int limit=5)
        {
            if(String.Equals(q, "bands"))
            {
                System.Diagnostics.Debug.WriteLine("Getting bands for user " + fanId);

                List<Bands> bands = new List<Bands>();
                Bands band = new Bands();
                band.Name = "Metallica";
                band.Id = 1;
                band.DateCreation = "9/10/1925";
                bands.Add(band);

                Bands band2 = new Bands();
                band2.Name = "Pink Floyd";
                band2.Id = 2;
                band2.DateCreation = "9/10/2010";
                bands.Add(band2);


                clsResponse response = new clsResponse();
                response.Success = true;
                response.Message = "mamo";
                response.Data = JsonConvert.SerializeObject(bands);
                return Ok(response);
            }
            if(String.Equals(q, "news"))
            {
                System.Diagnostics.Debug.WriteLine("Getting news for user " + fanId);
                clsResponse response = new clsResponse();
                response.Success = true;
                response.Message = "mamo2";
           
                return Ok(response);
            }
            if (String.Equals(q, "events"))
            {
                System.Diagnostics.Debug.WriteLine("Getting events for user " + fanId);
                clsResponse response = new clsResponse();
                response.Success = true;
                response.Message = "mamo3";
  
                return Ok(response);
            }

            //Endpoint for retrieving one fan
            throw new NotImplementedException();
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
