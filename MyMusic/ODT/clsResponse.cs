using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class clsResponse
    {
        public int Code { get; set; }
        public bool Success { get; set; } //success/fail of request
        public String Message { get; set; }
        public String Data { get; set; }


        public clsResponse()
        {
            //inicializa las variables en estado de exito

            Code = 200; 
            Success = true;
            Message = "";
            Data = null;
        }

        public String toJson()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
