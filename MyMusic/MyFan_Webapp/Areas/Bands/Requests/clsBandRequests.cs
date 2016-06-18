using MyFan_Webapp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MyFan_Webapp.Areas.Bands.Requests
{
    public class clsBandRequests
    {
        public static async Task<List<string>> GetBandProfile(int userId)
        {

            var requestAlbums = clsHttpClient.getClient().GetAsync("users/bands/" + userId + "/?q=albums");
            var requestPosts = clsHttpClient.getClient().GetAsync("users/bands/" + userId + "/?q=posts");

            await Task.WhenAll(requestAlbums, requestPosts);

            System.Diagnostics.Debug.WriteLine("albums " + requestAlbums.Result.Content.ReadAsStringAsync().Result);
            System.Diagnostics.Debug.WriteLine("posts " + requestPosts.Result.Content.ReadAsStringAsync().Result);

            List<string> response = new List<string>();
            if (requestAlbums.Result.IsSuccessStatusCode)
            {
                response.Add(requestAlbums.Result.Content.ReadAsStringAsync().Result);
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

        public static async Task<string> GetBandInfo(int Id)
        {
            // HTTP GET
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + Id + "/?q=all");
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