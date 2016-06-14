using System;
using System.Web.Http;
using MyFan_API.ControllerCalls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyFan_API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        [Route("users"), HttpGet]
        public IHttpActionResult GetUsers(string q, string action, string value)
        {
            if(String.Equals(q.ToLower(), "username") && String.Equals(action.ToLower(), "validate") && (value.ToLower() != null))
            {
                return new UserControllerCallsValidateUsername(Request, value);
            }
            if (String.Equals(q.ToLower(), "image") && String.Equals(action.ToLower(), "read") && (value.ToLower() != null))
            {

                /*

                String filePath = @"C:/Users/svk19/Source/Repos/MyMusic/MyMusic/MyFan_API/Data/Profiles/Images/stiven.png";


                var result = new HttpResponseMessage(HttpStatusCode.OK);

                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Image image = Image.FromStream(fileStream);
                MemoryStream memoryStream = new MemoryStream();
                image.Save(memoryStream, ImageFormat.Jpeg);
                var byteArrayContent = new ByteArrayContent(memoryStream.ToArray());
                byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                result.Content = byteArrayContent;
                return result;
                */


            }
        
            
            throw new NotImplementedException();
        }

        [Route("users/login"), HttpPost]
        public IHttpActionResult Login()
        {
            return new UserControllerCallsLoginUser(Request);

            //Endpoint for retrieving all users
            throw new NotImplementedException();
        }

      /*  private void register(string v)
        {
            string hashedForSending = BCrypt.Net.BCrypt.HashPassword(v);
            System.Diagnostics.Debug.WriteLine("Hash when sended " + hashedForSending);
            //Generate salt for user
            string mySalt = BCrypt.Net.BCrypt.GenerateSalt(13);
            System.Diagnostics.Debug.WriteLine("unique salt for user " + mySalt);
            //Rehash password
            string password = BCrypt.Net.BCrypt.HashPassword(hashedForSending, mySalt);
            System.Diagnostics.Debug.WriteLine("Final password " + password);
            System.Diagnostics.Debug.WriteLine("\n");
        }*/
    }
}
