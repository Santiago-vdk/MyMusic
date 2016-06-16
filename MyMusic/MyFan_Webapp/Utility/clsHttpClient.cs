using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyFan_Webapp.Requests
{
    public static class clsHttpClient
    {
        public static HttpClient getClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiEndpoint"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}