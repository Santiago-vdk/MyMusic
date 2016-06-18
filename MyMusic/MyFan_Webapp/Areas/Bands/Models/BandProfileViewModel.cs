using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Bands.Models
{
    public class BandProfileViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public List<clsAlbum> Albums { get; set; }
        public List<clsPublication> Posts { get; set; }
    }
}