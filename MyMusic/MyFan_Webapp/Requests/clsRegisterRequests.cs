using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;

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
                HttpResponseMessage response = await client.GetAsync("users/fans?q=form");
                ErrorInterpreter ErrorInterpreter = new ErrorInterpreter(Int32.Parse(response.StatusCode.ToString()));

                //Aqui evaluar los codigos http

                if (response.IsSuccessStatusCode)
                {
                    string JsonResponse = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonResponse);
                }
                else { return null; }
            }
        }
        
    }
}