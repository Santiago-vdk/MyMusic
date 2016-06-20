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

        public static async Task<string> UpdateEvent(int userId, int eventId, string value)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/bands/" + userId + "/events/" + eventId + "/?q=state&value=" + value, "");
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

        public static async Task<string> GetAllEventReviews(int userId, int eventId)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + userId + "/events/" + eventId + "/?q=reviews");
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

        public static async Task<string> GetEventReview(int fanId, int bandId, int eventId)
        {
            clsRequest RequestObject = new clsRequest("-1", fanId, fanId.ToString());
            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/bands/" + bandId + "/events/" + eventId + "/?q=reviewzz", RequestObject);
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

        public static async Task<string> DeleteEventReview(int fanId, int eventId)
        {
            clsRequest RequestObject = new clsRequest("-1", fanId, fanId.ToString());
            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/bands/" + fanId + "/events/" + eventId + "/?q=delete", RequestObject);
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

        public static async Task<string> DeleteEvent(int userId, int eventId, string value)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().DeleteAsync("users/bands/" + userId + "/events/" + eventId );
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

        internal static async Task<string> PostReview(int fanId, int bandId,int eventId, string rate, string comment, string fanName)
        {
            Serializer serializer = new Serializer();
            clsReview form = new clsReview();
            form.Author = fanName;
            form.Calification = rate;
            form.Comment = comment;

            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", fanId, RequestBody);

            HttpResponseMessage request = await clsHttpClient.getClient().PutAsJsonAsync("users/bands/" + bandId + "/events/" + eventId + "/?q=review" , RequestObject);
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