using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MyFan_Webapp
{
    public class ErrorInterpreter
    {
        private int StatusCode;

        public ErrorInterpreter(int pIntStatusCode)
        {
            StatusCode = pIntStatusCode;
        }

        public bool isError()
        {
            return false;
        }




    }
}