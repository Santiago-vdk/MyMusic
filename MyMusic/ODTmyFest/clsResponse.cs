using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODTmyFest
{
    public class clsResponse
    {

        public int Code { get; set; }
        public bool Success { get; set; } //success/fail of request
        public string Message { get; set; }
        public string Data { get; set; }


        public clsResponse()
        {
            //inicializa las variables en estado de exito
            Code = 200;
            Success = true;
            Message = "";
            Data = null;
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
