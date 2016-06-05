using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using Newtonsoft.Json;

namespace MyFan_Webapp.Requests.Register
{
    public class clsRegisterRequests
    {

        public static async Task<FanForm> GetRegisterFanForm()
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
                    string json = await response.Content.ReadAsAsync<string>();
                    FanForm form = JsonConvert.DeserializeObject<FanForm>(json);
                    System.Diagnostics.Debug.WriteLine(form);
                    return await Task.FromResult(form);
                }
                else
                {
                    return null;
                }

            }
        }

        /*string inputUsername, string inputPassword, string inputConfirmPassword,
        string inputName, string inputBirthday, string selectGenre, string selectCountry,
    string[] selectMusicalGenres, string accept*/


        /*internal static async Task PostRegisterForm(string inputUsername, string inputPassword, string inputConfirmPassword,
            string inputName, string inputBirthday, string selectGenre, string selectCountry,
            string[] selectMusicalGenres, string accept)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:63917/api/v1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var request = new Request()
                {
                    Username = inputUsername,
                    Password = inputPassword,
                    ConfirmPassword = inputConfirmPassword,
                    Name = inputName,
                    Birthday = inputBirthday,
                    Genre = selectGenre,
                    Country = selectCountry,
                    MusicalGenres = selectMusicalGenres,
                    Accept = accept
                };



                HttpResponseMessage response = await client.PostAsJsonAsync("users/fans", request);
                System.Diagnostics.Debug.WriteLine(response.StatusCode);
                if (response.IsSuccessStatusCode)
                {

                    Uri requestUrl = response.Headers.Location;
                }

            }
        }*/
    }
}