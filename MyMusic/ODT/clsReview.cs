using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DTO
{
    public class clsReview
    {
        public IUser Author { get; set; }
        public String Calification { get; set; }
        public String Comment { get; set; }
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public String ErrorMessage { get; set; }

        public String toJson()
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            // String json = "Success:" + Success + "," + "ErrorCode:" + ErrorCode + "," + "ErrorMessage:" + ErrorMessage + "," + "Data:";
            String json = "";
            String data = javaScriptSerializer.Serialize(this);
            json += data;
            return json;
        }

    }
}