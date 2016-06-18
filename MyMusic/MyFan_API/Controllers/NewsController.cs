using MyFan_API.ControllerCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1/users/bands/{bandId}/news")]
    public class NewsController : ApiController
    {

        [Route(""), HttpPost]
        // api/v1/users/bands/1/news POST
        public IHttpActionResult CreateNew(int bandId)
        {
            return new NewControllerCallsCreateNew(Request, bandId);
            //Endpoint for creating a New for a band
            throw new NotImplementedException();
        }

        [Route("")]
        [HttpGet]
        // api/v1/users/bands/1/news GET
        public IHttpActionResult GetAllNews(int bandId)
        {
            //Endpoint for retrieving all news of a band
            throw new NotImplementedException();
        }

        [Route("{newId}")]
        [HttpGet]
        // api/v1/users/bands/1/news/1 GET
        public IHttpActionResult GetOneNew(int bandId, int newId)
        {
            //Endpoint for retrieving one new of a band
            throw new NotImplementedException();
        }

        [Route("{newId}")]
        [HttpPut]
        // api/v1/users/bands/1/news/1 PUT
        public IHttpActionResult UpdateOneNew(int bandId, int newId)
        {
            //Endpoint for updating one new of a band
            throw new NotImplementedException();
        }

        [Route("{newId}")]
        [HttpDelete]
        // api/v1/users/bands/1/news/1 DELETE
        public IHttpActionResult DeleteOneNew(int bandId, int newId)
        {
            //Endpoint for deleting one new of a band
            throw new NotImplementedException();
        }

    }
}
