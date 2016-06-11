using BusinessLogic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyFan_API
{
    public class FanControllerCallsGetForm : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public FanControllerCallsGetForm(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.getFanForm()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }

    public class FanControllerCallsRegisterFan : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;

        public FanControllerCallsRegisterFan(HttpRequestMessage request)
        {
            _request = request;
            _facade = new FacadeBL();
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createFan(_request.Content.ReadAsStringAsync().Result)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}