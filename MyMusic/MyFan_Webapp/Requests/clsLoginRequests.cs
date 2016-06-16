using DTO;
using MyFan_Webapp.Requests;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utility;

namespace MyFan_Webapp.Controllers
{
    public class clsLoginRequests
    {
        public static async Task<string> PostLoginUserForm(PostLoginUserForm form)
        {
            // HTTP POST
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);

            clsRequest RequestObject = new clsRequest("-1", -1, RequestBody);
            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/login", RequestObject);
            System.Diagnostics.Debug.WriteLine(request);
            if (request.IsSuccessStatusCode)
            {
                string response = request.Content.ReadAsStringAsync().Result;
                return await Task.FromResult(response);
            }
            else
            {
                return await Task.FromResult("Unexpected error ocurred");
            }
        }
    }
}
