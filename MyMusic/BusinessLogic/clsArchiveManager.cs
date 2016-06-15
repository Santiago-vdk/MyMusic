using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DTO;

namespace BusinessLogic
{
    class clsArchiveManager
    {
               
        public void saveUserImage(string pstringUsername, string pstringImage,ref clsResponse pclsResponse)
        {
            try
            {

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/")) //directory does not exist
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/");
                }
                System.Diagnostics.Debug.WriteLine("Path: " + AppDomain.CurrentDomain.BaseDirectory);

                System.Diagnostics.Debug.WriteLine("IMAGE: "+pstringImage);

                const string FileTypePrefixJpg = "data:image/jpg;base64,";
                const string FileTypePrefixPng = "data:image/png;base64,";
                const string FileTypePrefixGif = "data:image/gif;base64,";

                string c = pstringImage.Substring(FileTypePrefixGif.Length);
                byte[] imageBytes = Convert.FromBase64String(c);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = Image.FromStream(ms, true);

                //type validations
                if (pstringImage.Contains(FileTypePrefixJpg))
                {
                    
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pstringImage.Contains(FileTypePrefixPng))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (pstringImage.Contains(FileTypePrefixGif))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
            catch
            {
                pclsResponse.Code = 5;
                pclsResponse.Message = "Error handling picture";
                pclsResponse.Success = false;
            }
               
        }

        public string getUserImage(string pstringUsername,  ref clsResponse pclsResponse)
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
            return "";
        }
    }
}
