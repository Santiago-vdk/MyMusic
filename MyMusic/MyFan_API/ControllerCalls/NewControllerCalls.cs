using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyFan_API.ControllerCalls
{
    public class NewControllerCallsCreateNew : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _userId;


        public NewControllerCallsCreateNew(HttpRequestMessage request, int userId)
        {
            _request = request;
            _facade = new FacadeBL();
            _userId = userId;

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createNew(_request.Content.ReadAsStringAsync().Result, _userId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

}