﻿using DTO;
using Newtonsoft.Json;

namespace MyFan_Webapp
{
    public class ErrorParser
    {
        internal string parse(string pStringJson)
        {
            clsResponse Response = JsonConvert.DeserializeObject<clsResponse>(pStringJson);
            if (Response.Success)
            {
                return "";
            }
            else
            {
                return HandleError(Response.Code,Response.Message);
            }


        }

        private string HandleError(int pIntCode, string pStringMessage)
        {
            if(pIntCode == 1)
            {
                return "Unable to retrieve information...";
            }
            if (pIntCode == 0)
            {
                return "The monkeys took a break... Please try again later :/";
            }
           
            return pStringMessage;
        }
    }
}