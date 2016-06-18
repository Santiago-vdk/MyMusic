using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsDisk
    {
        public string Name { get; set; }
        public List<clsSong> Songs { get; set; }
        public string Label { get; set; }
        public int Id { get; set; }
        public string DateCreation { get; set; }
        public string Picture { get; set; }
        
    }
}