using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsDisc
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public List<clsSong> Songs { get; set; }
        public List<clsReview> Reviews { get; set; }
        public string Label { get; set; } 
    }
}