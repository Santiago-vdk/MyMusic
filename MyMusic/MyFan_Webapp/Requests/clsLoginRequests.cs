using DTO;
using MyFan_Webapp.Controllers;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utility;

namespace MyFan_Webapp.Requests
{
    public class clsLoginRequests
    {
         public static async Task<string> PostLoginForm(PostLoginForm form)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                Serializer Serializer = new Serializer();
                string RequestBody = JsonConvert.SerializeObject(form);

                clsRequest RequestObject = new clsRequest("-1",-1,RequestBody);
                HttpResponseMessage request = await client.PostAsJsonAsync("users/login", JsonConvert.SerializeObject(RequestObject));
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