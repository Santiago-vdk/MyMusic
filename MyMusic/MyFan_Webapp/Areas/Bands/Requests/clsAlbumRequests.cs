﻿using DTO;
using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Requests;
using System.Net.Http;
using System.Threading.Tasks;
using Utility;
using System;

namespace MyFan_Webapp.Areas.Bands.Requests
{
    public class clsAlbumRequests
    {
        public static async Task<string> PostAlbumForm(clsAlbum form, int Id)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", Id, RequestBody);

            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands/" + Id + "/albums", RequestObject);
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

        public static async Task<string> GetAlbumInfo(int userId, int id)
        {
            // HTTP GET
            HttpResponseMessage request = await clsHttpClient.getClient().GetAsync("users/bands/" + userId + "/albums/" + id + "/?q=all");
            System.Diagnostics.Debug.WriteLine(request);
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

        public static async Task<string> PostSongForm(clsSong form, int userId, int albumId)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", userId, RequestBody);
            System.Diagnostics.Debug.WriteLine(RequestBody);
            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands/" + userId + "/albums/" + albumId + "/songs"  , RequestObject);
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