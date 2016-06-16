using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models
{
    public class VMFanProfile
    {
        public string Username { get; set; }
        public List<clsBands> Bands { get; set; }
        public List<News> News { get; set; }
        public List<Events> Events { get; set; }
        public List<clsPublication> Posts { get; set; }
        public int Id { get; set; }

    }
}