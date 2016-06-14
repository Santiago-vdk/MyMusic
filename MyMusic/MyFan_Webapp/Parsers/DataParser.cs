using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DTO;
using MyFan_Webapp.Models;
using MyFan_Webapp.Controllers;
using MyFan_Webapp.Models.Views;

namespace MyFan_Webapp
{
    public static class DataParser
    {
        public static Form parseFanForm(string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);
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

        public static Form parseBandForm(string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);

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
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);
            System.Diagnostics.Debug.WriteLine(Response.Data);
            dynamic data = JObject.Parse(Response.Data);

            int id = Convert.ToInt32(data.Id);
            string username= Convert.ToString(data.Username);

            UserSession session = new UserSession();
            session.Id = id;
            session.Username = username;

            return session;
            
        }
    }
}