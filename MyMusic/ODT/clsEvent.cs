using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODT
{
    public class clsEvent
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Location { get; set; }
        public Boolean IsConcert { get; set; }
        public Boolean State { get; set; }
        public List<Review> Reviews { get; set; }    
    }
}