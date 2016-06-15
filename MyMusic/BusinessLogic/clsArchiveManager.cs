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

        public string getUserImage(string pstringUsername)
        {
            try
            {
                // Load file meta data with FileInfo
                string path = "";
                string path1 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".jpeg";
                string path2 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".png";
                string path3 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".gif";

                string FileTypePrefix = "";
                const string FileTypePrefixJpg = "data:image/jpg;base64,";
                const string FileTypePrefixPng = "data:image/png;base64,";
                const string FileTypePrefixGif = "data:image/gif;base64,";

                if (Directory.Exists(path1))
                {
                    path = path1;
                    FileTypePrefix = FileTypePrefixJpg;
                }
                if (Directory.Exists(path2))
                {
                    path = path2;
                    FileTypePrefix = FileTypePrefixPng;
                }
                if (Directory.Exists(path3))
                {
                    path = path3;
                    FileTypePrefix = FileTypePrefixGif;
                }

                FileInfo fileInfo = new FileInfo(path);

                // The byte[] to save the data in
                byte[] data = new byte[fileInfo.Length];

                // Load a filestream and put its content into the byte[]
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(data, 0, data.Length);
                }
                // Delete the temporary file
                fileInfo.Delete();

                return FileTypePrefix + Convert.ToBase64String(data);
            }
            catch
            {
                return "-1";
            }
        }
        public void updateUserImage(string pstringUsername, string pstringImage, ref clsResponse pclsResponse)
        {
            try
            {

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/")) //directory does not exist
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/"+pstringUsername+".jpeg")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".jpeg");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".png")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".png");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".gif")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pstringUsername + ".gif");
                }

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
    }
}
