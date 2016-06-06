using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyFan_Webapp
{
    public class Request
    {


        public string Token { get; set; }
        public int Id { get; set; }
        public string Data { get; set; }

        public Request(string pStringToken, int pIntId, string pStringData)
        {
            Token = pStringToken;
            Id = pIntId;
           Data = pStringData;
        }

    }
}