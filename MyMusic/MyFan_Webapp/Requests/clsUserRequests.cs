using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Utility;

namespace MyFan_Webapp.Requests
{
    public class clsUserRequests
    {
        public static async Task<string> GetProfilePicture(int Id)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users?q=image&action=read&value=" + Id);
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
        public static async Task<string> GetSearchParams()
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/fans?q=search_values");
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

        public static async Task<string> Search(clsSearch SearchParams)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(SearchParams);
            
            clsRequest RequestObject = new clsRequest("-1", -1, RequestBody);

            
            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/search", RequestObject);
  
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