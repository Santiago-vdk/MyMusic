using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models.ViewModels
{
    public class ViewModelBase
    {
        public ViewModelBase()

        {

            BaseTitle = "Countries of the world";


        }

        public static String BaseTitle { get; private set; }

        public String Title { get; set; }



    }
}