using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyFan_API
{
    public class clsFanResult : IHttpActionResult
    {
        HttpRequestMessage _request;

        public clsFanResult(HttpRequestMessage request)
        {
            _request = request;
        }

        class JSON
        {
            public int code { get; set; }
            public bool success { get; set; }
            public string[] data { get; set; }
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            JSON obj = new JSON();
            obj.code = 200;
            obj.success = true;
            obj.data = new string[] { "Indie","Rock","Reggae","Metal","Techno","House" };

            string json = JsonConvert.SerializeObject(obj);


            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(json);
            

            // NOTE: Here I am just setting the result on the Task and not really doing any async stuff. 
            // But let's say you do stuff like contacting a File hosting service to get the file, then you would do 'async' stuff here.

            return Task.FromResult(response);


            /*
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json),
                RequestMessage = _request

            };
            return Task.FromResult(response);*/
        }
    }
}