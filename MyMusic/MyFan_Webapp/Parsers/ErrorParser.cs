﻿using System;
using DTO;
using Newtonsoft.Json;

namespace MyFan_Webapp
{
    public static class ErrorParser
    {
        public static bool hasContent(string pStringJson)
        {
            if (pStringJson.Equals("no-content"))
            {
                return false;
            }
            return true;
        }

        public static string parseUsernameOrHashtag(string pStringJson)
        {

            clsResponse Response = DataParser.parseResponse(pStringJson);
            if (Response.Success)
            {
                return ""; //El usuario si existe
            }
            else
            {
                return "-1";
            }

        }

        public static string parse(string pStringJson)
        {

            clsResponse Response = DataParser.parseResponse(pStringJson);
            if (Response.Success)
            {
                return "";
            }
            else
            {
                return HandleError(Response.Code, Response.Message);
            }
        }

        private static string HandleError(int pIntCode, string pStringMessage)
        {
            if (pIntCode == 1)
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