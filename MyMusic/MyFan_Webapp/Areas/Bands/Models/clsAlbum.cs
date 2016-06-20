using DTO;
using System.Collections.Generic;

namespace MyFan_Webapp.Areas.Bands.Models
{
    public class clsAlbum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateCreation { get; set; }
        public int Genre { get; set; }
        public string Picture { get; set; }
        public string Label { get; set; }
        public List<clsReview> Reviews { get; set; }
    }
}