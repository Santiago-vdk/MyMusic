using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MyFan_API
{
    public interface IHttpActionResult
    {
        Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
}