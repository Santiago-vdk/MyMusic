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
            var requestNews = Client.getClient().GetAsync("users/fans/" + userId + "/?q=news");
            var requestEvents = Client.getClient().GetAsync("users/fans/" + userId + "/?q=events");

            await Task.WhenAll(requestBands, requestNews, requestEvents);

            System.Diagnostics.Debug.WriteLine("bands " + requestBands.Result.Content.ReadAsStringAsync().Result);
            System.Diagnostics.Debug.WriteLine("news " + requestNews.Result.Content.ReadAsStringAsync().Result);
            System.Diagnostics.Debug.WriteLine("events " + requestEvents.Result.Content.ReadAsStringAsync().Result);

            List<string> response = new List<string>();
            if (requestBands.Result.IsSuccessStatusCode)
            {
                response.Add(requestBands.Result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                response.Add("Unexpected error ocurred");
            }

            if (requestNews.Result.IsSuccessStatusCode)
            {
                response.Add(requestNews.Result.Content.ReadAsStringAsync().Result);
            }
            else
            {
                response.Add("Unexpected error ocurred");
            }

            if (requestEvents.Result.IsSuccessStatusCode)
            {
                response.Add(requestEvents.Result.Content.ReadAsStringAsync().Result);

            }
            else
            {
                response.Add("Unexpected error ocurred");
            }

            return response;
        }
    }
}




