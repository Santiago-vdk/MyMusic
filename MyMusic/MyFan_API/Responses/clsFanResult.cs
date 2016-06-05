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
        string _value;
        HttpRequestMessage _request;

        public clsFanResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                RequestMessage = _request
                
            };
            return Task.FromResult(response);
        }
    }
}