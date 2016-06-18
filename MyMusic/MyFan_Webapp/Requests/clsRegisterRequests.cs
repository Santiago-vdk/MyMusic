using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using DTO;
using MyFan_Webapp.Models;
using Utility;
using Newtonsoft.Json;

namespace MyFan_Webapp.Requests.Register
{
    public class clsRegisterRequests
    {

        public static async Task<string> GetRegisterFanForm()
        {
            // HTTP GET
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/fans?q=form");
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
        
        public static async Task<string> PostRegisterFanForm(RegisterFanForm form)
        {
            Serializer Serializer = new Serializer();
            string RequestBody = Serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", -1, RequestBody);

            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/fans", RequestObject);
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

        public static async Task<string> ValidateUsername(string Username)
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users?q=username&action=validate&value=" + Username);

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

        public static async Task<string> GetRegisterBandForm()
        {
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands?q=form");
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

        public static async Task<string> PostRegisterBandForm(PostRegisterBandForm form)
        {
            Serializer Serializer = new Serializer();
            string RequestBody = Serializer.Serialize(form);
            System.Diagnostics.Debug.WriteLine("Body " + RequestBody);
            clsRequest RequestObject = new clsRequest("-1", -1, RequestBody);
            System.Diagnostics.Debug.WriteLine(RequestObject.Data);
            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands", RequestObject);
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