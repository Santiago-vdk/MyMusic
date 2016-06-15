using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MyFan_Webapp.Requests
{
    public class clsUserRequests
    {
        public static async Task<string> GetProfilePicture(int Id)
        {
            using (var client = new HttpClient())
            {
                
                // HTTP GET
                HttpResponseMessage request = await Client.getClient().GetAsync("users?q=image&action=read&value=" + Id);
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
}