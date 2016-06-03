using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_API.Layer_Objects
{
    public class clsSong
    {
        public String Name { get; set; }
        public String Duration { get; set; }
        public Boolean Type { get; set; }
        public String Link { get; set; }
    }
}