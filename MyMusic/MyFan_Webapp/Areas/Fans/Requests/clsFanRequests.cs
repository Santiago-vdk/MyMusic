using DTO;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Requests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyFan_Webapp.Areas.Fans.Requests
{
    public class clsFanRequests
    {
        public static async Task<List<string>> GetFanProfile(int userId)
        {

            var requestBands = Client.getClient().GetAsync("users/fans/" + userId + "/?q=bands");
            var requestPosts = Client.getClient().GetAsync("users/fans/" + userId + "/?q=posts");
    
            await Task.WhenAll(requestBands, requestPosts);

            System.Diagnostics.Debug.WriteLine("bands " + requestBands.Result.Content.ReadAsStringAsync().Result);
            System.Diagnostics.Debug.WriteLine("posts " + requestPosts.Result.Content.ReadAsStringAsync().Result);        

            List<string> response = new List<string>();
            if (requestBands.Result.IsSuccessStatusCode)
            {
                if(requestBands.Result.Content.ReadAsStringAsync().Result.Length > 0)
                {
                    response.Add(requestBands.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    response.Add("no-content");
                }
            }
            else
            {
                response.Add("Unexpected error ocurred with favorite bands");
            }

            if (requestPosts.Result.IsSuccessStatusCode)
            {
                response.Add(requestPosts.Result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                response.Add("Unexpected error ocurred with posts");
            }

            return response;
        }
    }
}




