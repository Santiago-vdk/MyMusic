using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                if (response.IsSuccessStatusCode)
                {
                    string JsonResponse = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonResponse);
                }
                else //if ((int) response.StatusCode == 500)
                {
                    return await Task.FromResult("Unexpected error ocurred");
                }

            }
        }
/*
        public static async Task<string> PostRegisterFanForm(string inputUsername, string inputPassword, string inputConfirmPassword, 
            string inputName, string inputBirthday, string selectGenre, string selectCountry, List<string> selectMusicalGenres)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                PostRegisterFanForm RequestObj = new PostRegisterFanForm(inputUsername, inputPassword, inputConfirmPassword,
            inputName, inputBirthday, selectGenre, selectCountry, selectMusicalGenres);

                // HTTP POST
                string RequestBody = RequestObj.toJson();
                System.Diagnostics.Debug.WriteLine(RequestBody);
                Request request = new Request("-1",-1,RequestBody);

                HttpResponseMessage response = await client.PostAsJsonAsync("users/fans", JsonConvert.SerializeObject(request));
                if (response.IsSuccessStatusCode)
                {
                    string JsonResponse = response.Content.ReadAsStringAsync().Result;
                    return await Task.FromResult(JsonResponse);
                }
                else
                {
                    return await Task.FromResult("Unexpected error ocurred");
                }
            }
        }*/
    }
}