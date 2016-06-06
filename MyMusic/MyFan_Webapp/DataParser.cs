using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DTO;

namespace MyFan_Webapp
{
    public class DataParser
    {

        internal GetRegisterFanForm parseFanForm(GetRegisterFanForm form, string json)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(json);
            
            dynamic data = JObject.Parse(Response.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));
            List<string> genders = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genders));

            form.genres = genres;
            form.genders = genders;

            return form;
        }
    }
}