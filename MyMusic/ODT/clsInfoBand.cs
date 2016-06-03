using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODT
{
    public class clsInfoBand
    {
        public String Name { get; set; }
        public String DateCreation { get; set; }
        public List<String> Genres { get; set; }
        public String Country { get; set; }
        public String Hashtag { get; set; }
        public List<Member> Members { get; set; }
    }
}