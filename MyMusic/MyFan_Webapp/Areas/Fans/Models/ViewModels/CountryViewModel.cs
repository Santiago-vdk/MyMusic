using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models.ViewModels
{
    public class CountryViewModel : IndexViewModel

    {

        public String Country { get; set; }

        public String Area { get; set; }

        public String Capital { get; set; }

        public String Population { get; set; }

        public CountryViewModel GetCountryViewModel()
        {
            return this;
        }
    }
}