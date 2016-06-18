using DTO;
using MyFan_Webapp.Models.Views;
using System.Collections.Generic;

namespace MyFan_Webapp.Areas.Fans.Models
{
    public class FanProfileViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public List<clsBands> Bands { get; set; }
        public List<News> News { get; set; }
        public List<Events> Events { get; set; }
        public List<clsPublication> Posts { get; set; }
        public int Id { get; set; }
        public Form EditForm { get; set; }
        public clsInfoFan Info { get; set; }
        public List<clsBands> SearchResults { get; set; }
        public clsInfoBand BandInfo { get; set; }

    }
}