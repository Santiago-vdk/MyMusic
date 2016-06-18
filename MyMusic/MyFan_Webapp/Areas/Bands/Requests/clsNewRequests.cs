using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DTO;
using Utility;
using MyFan_Webapp.Requests;
using System.Net.Http;

namespace MyFan_Webapp.Areas.Bands.Requests
{
    public class clsNewRequests
    {
        public static async Task<string> PostNewForm(clsNew form, int userId)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", userId, RequestBody);
            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands/" + userId + "/news", RequestObject);
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

        public static async Task<string> GetNew(int userId, int id)
        {
            // HTTP GET
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + userId + "news/" + id );
            
            if (request.IsSuccessStatusCode)
            {
                string response = request.Content.ReadAsStringAsync().Result;
                return await Task.FromResult(response);
            }
            else //if ((int) response.StatusCode == 500)
            {
                return await Task.FromResult("Unexpected error ocurred");
            }
        }
    }
}