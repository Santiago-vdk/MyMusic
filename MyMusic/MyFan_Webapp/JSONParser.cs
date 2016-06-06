using System;
using System.Collections.Generic;
using MyFan_Webapp.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MyFan_Webapp
{
    public class JSONParser
    {

        internal FanForm parseFanForm(FanForm form, string json)
        {
            JSONResponse jsonresponse = JsonConvert.DeserializeObject<JSONResponse>(json);

            dynamic data = JObject.Parse(jsonresponse.Data);

            List<string> genres = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genres));
            List<string> genders = JsonConvert.DeserializeObject<List<string>>(Convert.ToString(data.genders));

            form.genres = genres;
            form.genders = genders;

            return form;
        }
    }
}