using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class clsDisc
    {
        public String Description { get; set; }
        public String Name { get; set; }
        public List<clsSong> Songs { get; set; }
        public List<clsReview> Reviews { get; set; }
        public String Label { get; set; }
    }
}