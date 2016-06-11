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
    
        public class UserControllerCallsLoginUser : IHttpActionResult
        {
            HttpRequestMessage _request;
            FacadeBL _facade;

            public UserControllerCallsLoginUser(HttpRequestMessage request)
            {
                _request = request;
                _facade = new FacadeBL();
            }
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response = new HttpResponseMessage()
                {
                   //Content = new StringContent(_facade.getFanForm()),
                    RequestMessage = _request
                };
                return Task.FromResult(response);
            }
        }
    
}