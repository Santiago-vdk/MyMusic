using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DTO;
using MyFan_Webapp.Models;
using MyFan_Webapp.Controllers;
using MyFan_Webapp.Models.Views;
using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Bands.Models;

namespace MyFan_Webapp
{
    public static class DataParser
    {
        private static List<Genre> parseGenres(string pStringGenres, string pStringGenresIds)
        {
            List<string> genres = JsonConvert.DeserializeObject<List<string>>(pStringGenres);
            List<int> genresIds = JsonConvert.DeserializeObject<List<int>>(pStringGenresIds);

            List<Genre> listGenres = new List<Genre>();
            for (int i = 0; i < genres.Count; i++)
            {
                Genre genre = new Genre();
                genre.Id = genresIds[i];
                genre.Name = genres[i];
                listGenres.Add(genre);
            }
            return listGenres;
        }

        private static List<Gender> parseGenders(string pStringGenders, string pStringGendersIds)
        {
            List<string> genders = JsonConvert.DeserializeObject<List<string>>(pStringGenders);
            List<int> gendersIds = JsonConvert.DeserializeObject<List<int>>(pStringGendersIds);

            List<Gender> listGenders = new List<Gender>();
            for (int i = 0; i < genders.Count; i++)
            {
                Gender gender = new Gender();
                gender.Id = gendersIds[i];
                gender.Name = genders[i];
                listGenders.Add(gender);
            }
            return listGenders;
        }

        public static clsNew parseNew(string json)
        {
            clsResponse Response = parseResponse(json);
            clsNew New = JsonConvert.DeserializeObject<clsNew>(Convert.ToString(Response.Data));
            return New;
        }

        public static clsDisk parseDisk(string json)
        {
            clsResponse Response = parseResponse(json);
            clsDisk disk = JsonConvert.DeserializeObject<clsDisk>(Convert.ToString(Response.Data));
            return disk;
        }

        public static int parseNewForm(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
          
            int NewId = JsonConvert.DeserializeObject<int>(Convert.ToString(data.Id));
            return NewId;
        }

        internal static clsInfoBand parseBandInfo(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);

            clsInfoBand infoBand = JsonConvert.DeserializeObject<clsInfoBand>(Convert.ToString(data));

            return infoBand;
        }

        public static BandProfileViewModel parseBandProfile(List<string> json)
        {
            BandProfileViewModel profile = new BandProfileViewModel();

            profile.Albums = parseAlbums(json[0]);
            profile.Posts = parsePosts(json[1]);

            return profile;

        }

        public static int parseAlbumForm(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
            System.Diagnostics.Debug.WriteLine(json);
            int albumId = JsonConvert.DeserializeObject<int>(Convert.ToString(data.Id));
            return albumId;
        }

        public static List<clsAlbum> parseAlbums(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
            System.Diagnostics.Debug.WriteLine(json);
            List<clsAlbum> albums = JsonConvert.DeserializeObject<List<clsAlbum>>(Convert.ToString(data.Disks));
            return albums;
        }

        private static List<Location> parseCountry(string pStringLocations, string pStringLocationsIds)
        {
            List<string> locations = JsonConvert.DeserializeObject<List<string>>(pStringLocations);
            List<int> locationsIds = JsonConvert.DeserializeObject<List<int>>(pStringLocationsIds);

            List<Location> listLocations = new List<Location>();
            for (int i = 0; i < locations.Count; i++)
            {
                Location location = new Location();
                location.Id = locationsIds[i];
                location.Name = locations[i];
                listLocations.Add(location);
            }
            return listLocations;
        }

 

        public static clsInfoFan parseFanInfo(string json)
        {
            clsResponse Response = parseResponse(json);
            return JsonConvert.DeserializeObject<clsInfoFan>(Response.Data);
        }

        public static Form parseFanForm(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);

            Form form = new Form();
            form.genres = parseGenres(Convert.ToString(data.genres), Convert.ToString(data.codGenres));
            form.genders = parseGenders(Convert.ToString(data.genders), Convert.ToString(data.codGenders));
            form.locations = parseCountry(Convert.ToString(data.locations), Convert.ToString(data.codLocations));

            return form;
        }



        public static FanProfileViewModel parseFanBands(string json)
        {
            FanProfileViewModel profile = new FanProfileViewModel();

            profile.Bands = parseBands(json);
            return profile;
        }

       

        public static bool hasContent(string json)
        {
            throw new NotImplementedException();
        }

        public static Form parseSearchParams(string json)
        {
            Form form = new Form();

            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
            
            form.genres = parseGenres(Convert.ToString(data.genres), Convert.ToString(data.codGenres));
            form.locations = parseCountry(Convert.ToString(data.locations), Convert.ToString(data.codLocations));
            return form;
        }

        public static FanProfileViewModel parseFanProfile(List<string> json)
        {
            FanProfileViewModel profile = new FanProfileViewModel();

            profile.Bands = parseBands(json[0]);
            profile.Posts = parsePosts(json[1]);

            return profile;

        }
        public static List<clsPublication> parsePosts(string json)
        {
            clsResponse Response = parseResponse(json);
            return JsonConvert.DeserializeObject<List<clsPublication>>(Response.Data);
        }

        public static List<clsBands> parseBands(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);
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

            Form form = new Form();
            form.genres = parseGenres(Convert.ToString(data.genres), Convert.ToString(data.codGenres));
            form.locations = parseCountry(Convert.ToString(data.locations), Convert.ToString(data.codLocations));
            return form;
        }

        public static UserSession parseUserForm(string json)
        {
            clsResponse Response = parseResponse(json);
            dynamic data = JObject.Parse(Response.Data);

            int id = Convert.ToInt32(data.Id);
            string username = Convert.ToString(data.Username);
            int rol = Convert.ToInt32(data.Rol);
            string name = Convert.ToString(data.Name);

            UserSession session = new UserSession();
            session.Id = id;
            session.Username = username;
            session.Rol = rol;
            session.Name = name;

            return session;

        }
    }
}