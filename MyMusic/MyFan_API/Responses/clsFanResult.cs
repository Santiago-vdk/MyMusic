using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyFan_API
{
    public class clsFanResult : IHttpActionResult
    {

        string _value;
        HttpRequestMessage _request;

        public clsFanResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }


        /*HttpRequestMessage _request;


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
            System.Diagnostics.Debug.WriteLine("called");
            JSON obj = new JSON();
            obj.code = 200;
            obj.success = true;
            obj.data = new string[] { "Indie","Rock","Reggae","Metal","Techno","House" };

            string json = JsonConvert.SerializeObject(obj);
            System.Diagnostics.Debug.WriteLine(json);

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(json);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.RequestMessage = _request;




            return Task.FromResult(response);


            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value),
                
                RequestMessage = _request
            };
            return Task.FromResult(response);
            
    }*/
    }
}