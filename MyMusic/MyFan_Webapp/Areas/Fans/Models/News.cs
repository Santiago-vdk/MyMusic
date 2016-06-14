using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Areas.Fans.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date  { get; set; }
    }
}