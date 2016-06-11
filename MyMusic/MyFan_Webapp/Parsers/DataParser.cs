using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DTO;
using MyFan_Webapp.Models;
using MyFan_Webapp.Controllers;

namespace MyFan_Webapp
{
    public static class DataParser
    {

        public static GetRegisterFanForm parseFanForm(GetRegisterFanForm form, string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);
            
            dynamic data = JObject.Parse(Response.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));
            List<string> genders = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genders));

            form.genres = genres;
            form.genders = genders;

            return form;
        }

        public static GetRegisterBandForm parseBandForm(GetRegisterBandForm form, string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);

            dynamic data = JObject.Parse(Response.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));

            form.genres = genres;

            return form;
        }

        internal Pint parseUserForm(string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);

            dynamic data = JObject.Parse(Response.Data);

            int id = JsonConvert.DeserializeObject<int>(Convert.ToInt32(data.id));

            return id;
        }
    }
}