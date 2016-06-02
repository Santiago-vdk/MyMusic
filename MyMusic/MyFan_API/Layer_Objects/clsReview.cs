using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_API.Layer_Objects
{
    public class Review
    {
        public User Author { get; set; }
        public String Calification { get; set; }
        public String Comment { get; set; }

    }
}