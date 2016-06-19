using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DTO;
using Utility;
using System.Net.Http;
using MyFan_Webapp.Requests;

namespace MyFan_Webapp.Areas.Bands.Requests
{
    public class clsEventRequests
    {
        public static async Task<string> createEvent(int userId, clsEvent form)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", userId, RequestBody);

            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands/" + userId + "/events", RequestObject);
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

        public static async Task<string> GetEvent(int userId, int eventId)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + userId + "/events/" + eventId);
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