using DTO;
using MyFan_Webapp.Requests;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Utility;
using System;

namespace MyFan_Webapp.Areas.Fans.Requests
{
    public class clsFanRequests
    {
        public static async Task<List<string>> GetFanProfile(int userId)
        {

            var requestBands = clsHttpClient.getClient().GetAsync("users/fans/" + userId + "/?q=bands");
            var requestPosts = clsHttpClient.getClient().GetAsync("users/fans/" + userId + "/?q=posts");

            await Task.WhenAll(requestBands, requestPosts);

            System.Diagnostics.Debug.WriteLine("bands " + requestBands.Result.Content.ReadAsStringAsync().Result);
            System.Diagnostics.Debug.WriteLine("posts " + requestPosts.Result.Content.ReadAsStringAsync().Result);

            List<string> response = new List<string>();
            if (requestBands.Result.IsSuccessStatusCode)
            {
                response.Add(requestBands.Result.Content.ReadAsStringAsync().Result);
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

        public static async Task<string> GetFanBands(int Id)
        {
            // HTTP GET
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/fans/" + Id + "/?q=bands");
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

        public static async Task<string> GetFanInfo(int Id)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/fans/" + Id + "/?q=all");
            if (request.IsSuccessStatusCode)
            {
                string response = request.Content.ReadAsStringAsync().Result;
                System.Diagnostics.Debug.WriteLine(response);
                return await Task.FromResult(response);
            }
            else //if ((int) response.StatusCode == 500)
            {
                return await Task.FromResult("Unexpected error ocurred");
            }
        }

        public static async Task<string> UpdateProfile(int Id, RegisterFanForm form)
        {

            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", Id, RequestBody);
            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/fans/" + Id, RequestObject);
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

        public static async Task<string> FollowBand(int fanId, int bandId)
        {

            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/fans/" + fanId + "?action=follow&value=" + bandId, "");
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

        public static async Task<string> UnFollowBand(int fanId, int bandId)
        {

            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/fans/" + fanId + "?action=unfollow&value=" + bandId, "");
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

        public static async Task<string> isFollowingBand(int fanId, int bandId)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/fans/" + fanId + "?q=isfollowing&value=" + bandId);
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


        public static async Task<string> GetBandStats(int fanId, int bandId)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + bandId + "/?q=stats");
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



      /*  public static async Task<string> GetBandOneReview(int fanId, int bandId)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + bandId + "/?q=review");
            if (request.IsSuccessStatusCode)
            {
                string response = request.Content.ReadAsStringAsync().Result;
                return await Task.FromResult(response);
            }
            else
            {
                return await Task.FromResult("Unexpected error ocurred");
            }
        }*/


    }
}




