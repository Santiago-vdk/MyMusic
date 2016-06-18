using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsNew
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public string BandName { get; set; }
    }
}