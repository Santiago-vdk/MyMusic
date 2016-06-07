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

        public String toJson()
        {
            return JsonConvert.SerializeObject(this);
            
        }     
    }
}
