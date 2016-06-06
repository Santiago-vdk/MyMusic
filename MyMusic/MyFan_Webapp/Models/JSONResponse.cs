using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp.Models
{
    public class JSONResponse
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Data { get; set; }

        public JSONResponse(int pIntCode, bool pBoolSuccess, string pStringData)
        {
            Code = pIntCode;
            Success = pBoolSuccess;
            Data = pStringData;
        }
    }
}