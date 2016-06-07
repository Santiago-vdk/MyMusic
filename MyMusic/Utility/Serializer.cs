using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Serializer
    {
        public Object tojson(Object pObjectObj)
        {
            return JsonConvert.SerializeObject(pObjectObj);
        }    
    }
}
