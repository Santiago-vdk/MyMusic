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
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage request = await client.GetAsync("users/fans?q=form");
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

        public static async Task<string> PostRegisterFanForm(PostRegisterFanForm form)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                Serializer Serializer = new Serializer();
                string RequestBody = Serializer.Serialize(form);
                clsRequest RequestObject = new clsRequest("-1",-1,RequestBody);

                HttpResponseMessage request = await client.PostAsJsonAsync("users/fans", RequestObject);
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

        public static async Task<string> ValidateUsername(string Username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                HttpResponseMessage request = await client.GetAsync("users?q=username&action=validate&value=" + Username);

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

        public static async Task<string> GetRegisterBandForm()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage request = await client.GetAsync("users/bands?q=form");
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

        public static async Task<string> PostRegisterBandForm(PostRegisterBandForm form)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                Serializer Serializer = new Serializer();
                string RequestBody = Serializer.Serialize(form);
                System.Diagnostics.Debug.WriteLine("Body " + RequestBody);
                clsRequest RequestObject = new clsRequest("-1", -1, RequestBody);
                HttpResponseMessage request = await client.PostAsJsonAsync("users/bands", RequestObject);
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
}