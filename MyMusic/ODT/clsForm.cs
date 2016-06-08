using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class clsForm
    {
        public List<String> genres { get; set; }
        public List<String> genders { get; set; }
        public List<String> locations { get; set; }
        public List<int> codGenres { get; set; }
        public List<int> codGenders { get; set; }
        public List<int> codLocations { get; set; }  
    }
}
