using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public bool IsConcert { get; set; }
        public bool State { get; set; }
        public List<clsReview> Reviews { get; set; }
        public int Id { get; set; }
    }
}