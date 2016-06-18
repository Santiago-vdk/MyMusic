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
 

    public class SongControllerCallsCreateSong : IHttpActionResult
    {
        HttpRequestMessage _request;
        FacadeBL _facade;
        int _bandId;
        int _albumId;

        public SongControllerCallsCreateSong(HttpRequestMessage request, int bandId, int albumId)
        {
            _request = request;
            _facade = new FacadeBL();
            _bandId = bandId;
            _albumId = albumId;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_facade.createSong(_request.Content.ReadAsStringAsync().Result, _bandId, _albumId)),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}