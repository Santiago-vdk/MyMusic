using MyFan_Webapp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}