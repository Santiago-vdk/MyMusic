using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MyFan_Webapp
{
    public class Client
    {

        public static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63578/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                System.Diagnostics.Debug.WriteLine("making request");
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("api/v1/users/fans/1");
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine("Ready");
                }

              
            }
        }

    }
}