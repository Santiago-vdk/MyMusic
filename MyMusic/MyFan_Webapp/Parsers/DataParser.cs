using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DTO;
using MyFan_Webapp.Models;
using MyFan_Webapp.Controllers;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Areas.Fans.Models;

namespace MyFan_Webapp
{
    public static class DataParser
    {
        public static Form parseFanForm(string json)
        {
            clsResponse Response = parseResponse(json);
            System.Diagnostics.Debug.WriteLine(json);
            dynamic data = JObject.Parse(Response.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));
            List<string> genders = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genders));
            List<string> locations = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.locations));
            List<int> genresIds = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.codGenres));
            List<int> gendersIds = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.codGenders));
            List<int> locationsIds = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.codLocations));

            Form form = new Form();
            List<Genre> listGenres = new List<Genre>();
            List<Gender> listGenders = new List<Gender>();
            List<Location> listLocations = new List<Location>();
            

            int i;
            for (i = 0; i < genres.Count; i++)
            {
                Genre genre = new Genre();
                genre.Id = genresIds[i];
                genre.Name = genres[i];
                listGenres.Add(genre);
            }
            for (i = 0; i < genders.Count; i++)
            {
                Gender gender = new Gender();
                gender.Id = gendersIds[i];
                gender.Name = genders[i];
                listGenders.Add(gender);
            }
            for (i = 0; i < locations.Count; i++)
            {
                Location location = new Location();
                location.Id = locationsIds[i];
                location.Name = locations[i];
                listLocations.Add(location);
            }


            form.genres = listGenres;
            form.genders = listGenders;
            form.locations = listLocations;

            return form;
        }

        public static VMFanProfile parseFanBands(string json)
        {
            VMFanProfile profile = new VMFanProfile();

            profile.Bands = parseBands(json);
            return profile;
        }

        public static bool hasContent(string json)
        {
            throw new NotImplementedException();
        }

        public static VMFanProfile parseFanProfile(List<string> json)
        {
            VMFanProfile profile = new VMFanProfile();

            profile.Bands = parseBands(json[0]);
            profile.Posts = parsePosts(json[1]);
            
            return profile;

        }
        private static List<clsPublication> parsePosts(string json)
        {
            clsResponse Response = parseResponse(json);
            return JsonConvert.DeserializeObject<List<clsPublication>>(Response.Data);
        }

        private static List<clsBands> parseBands(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
            System.Diagnostics.Debug.WriteLine(json);
            //dynamic data = JObject.Parse();
            List<clsBands> bands = JsonConvert.DeserializeObject<List<clsBands>>(Convert.ToString(data.Bands));
            return bands;
            
        }

        public static clsResponse parseResponse(string json)
        {
            return JsonConvert.DeserializeObject<clsResponse>(json);
        }

        public static Form parseBandForm(string json)
        {
            clsResponse Response = parseResponse(json);

            dynamic data = JObject.Parse(Response.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));
            List<string> locations = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.locations));
            List<int> genresIds = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.codGenres));
            List<int> locationsIds = JsonConvert.DeserializeObject<List<int>>(Convert.ToString(data.codLocations));

            Form form = new Form();
            List<Genre> listGenres = new List<Genre>();
            List<Location> listLocations = new List<Location>();

            int i;
            for (i = 0; i < genres.Count; i++)
            {
                Genre genre = new Genre();
                genre.Id = genresIds[i];
                genre.Name = genres[i];
                listGenres.Add(genre);
            }
            for (i = 0; i < locations.Count; i++)
            {
                Location location = new Location();
                location.Id = locationsIds[i];
                location.Name = locations[i];
                listLocations.Add(location);
            }

            form.genres = listGenres;
            form.locations = listLocations;

            return form;
        }

        public static UserSession parseUserForm(string json)
        {
            clsResponse Response = parseResponse(json);
            System.Diagnostics.Debug.WriteLine(Response.Data);
            dynamic data = JObject.Parse(Response.Data);

            int id = Convert.ToInt32(data.Id);
            string username= Convert.ToString(data.Username);
            int rol = Convert.ToInt32(data.Rol);

            UserSession session = new UserSession();
            session.Id = id;
            session.Username = username;
            session.Rol = rol;

            return session;
            
        }
    }
}