using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MyFan_Webapp.Requests.Register
{
    public class clsRegisterRequests
    {

        class Request
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public string Name { get; set; }
            public string Birthday { get; set; }
            public string Genre { get; set; }
            public string Country { get; set; }
            public string[] MusicalGenres { get; set; }
            public string Accept { get; set; }
        }


        internal static async Task RegisterRequest(string inputUsername, string inputPassword, string inputConfirmPassword,
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
        }
    }
}