using DTO;
using MyFan_Webapp.Models.Views;
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
        public clsInfoBand Info { get; set; }
        public Form EditForm { get; set; }
        public clsDisk Disk { get; set; }
    }
}