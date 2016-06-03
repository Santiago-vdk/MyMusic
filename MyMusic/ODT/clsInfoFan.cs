using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_API.Layer_Objects
{
    public class clsInfoFan
    {
        public String Name { get; set; }
        public String Birthday { get; set; }
        public String Gender { get; set; }
        public String Country { get; set; }
        public List<String> Genres { get; set; }


    }
}