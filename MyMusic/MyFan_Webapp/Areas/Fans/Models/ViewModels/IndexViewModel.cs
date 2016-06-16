using MyFan_Webapp.Areas.Fans.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models.ViewModels
{
    public class IndexViewModel : ViewModelBase

    {

        public IndexViewModel()
        {
            Bands = new List<clsBands>();
           
        }



        public List<clsBands> Bands { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }


    }
}