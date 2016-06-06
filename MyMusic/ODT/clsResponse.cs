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
        public int ErrorCode { get; set; }
        public bool ErrorState { get; set; } //success/fail of request
        public String ErrorMessage { get; set; }
        public String Data { get; set; }


        public clsResponse()
        {
            //inicializa las variables en estado de exito

            ErrorCode = 200; 
            ErrorState = true;
            ErrorMessage = "";
            Data = null;
        }

        public String toJson()
        {
            return JsonConvert.SerializeObject(this);

        }
    }
}
