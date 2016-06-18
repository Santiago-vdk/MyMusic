using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using DTO;
using System.Drawing.Imaging;

namespace BusinessLogic
{
    class clsArchiveManager
    {

        public void saveUserImage(int pintUserId, string pstringImage, ref clsResponse pclsResponse)
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

                System.Diagnostics.Debug.WriteLine("IMAGE: " + pstringImage);

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
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pstringImage.Contains(FileTypePrefixPng))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (pstringImage.Contains(FileTypePrefixGif))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
            catch
            {
                pclsResponse.Code = 5;
                pclsResponse.Message = "Error handling picture";
                pclsResponse.Success = false;
            }

        }
        public string getUserImage(int pintUserId)
        {
             try
             {
            // Load file meta data with FileInfo
            string path = "";
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".jpg";
            string path2 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".png";
            string path3 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".gif";

            if (File.Exists(path1))
            {
                path = path1;
            }
            if (File.Exists(path2))
            {
                path = path2;
            }
            if (File.Exists(path3))
            {
                path = path3;
            }
            using (Image image = Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }

            }
             catch
             {
                 return "-1";
             }
        }
        public void updateUserImage(int pintUserId, string pstringImage, ref clsResponse pclsResponse)
        {
            try
            {

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/")) //directory does not exist
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".jpg")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".jpg");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".png")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".png");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".gif")) //directory does not exist
                {
                    pclsResponse.Message = "Eliminando gif";
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".gif");
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
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pstringImage.Contains(FileTypePrefixPng))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (pstringImage.Contains(FileTypePrefixGif))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Profiles/Images/" + pintUserId.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
            catch
            {
                pclsResponse.Code = 5;
                pclsResponse.Message = "Error handling picture";
                pclsResponse.Success = false;
            }

        }


        public string getDiskImage(int pintDiskId)
        {
            try
            {
                // Load file meta data with FileInfo
                string path = "";
                string path1 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".jpg";
                string path2 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".png";
                string path3 = AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".gif";

                if (File.Exists(path1))
                {
                    path = path1;
                }
                if (File.Exists(path2))
                {
                    path = path2;
                }
                if (File.Exists(path3))
                {
                    path = path3;
                }
                using (Image image = Image.FromFile(path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }

            }
            catch
            {
                return "-1";
            }
        }
        public void saveDiskImage(int pintDiskId, string pstringImage, ref clsResponse pclsResponse)
        {
            try
            {

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/")) //directory does not exist
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/");
                }
                System.Diagnostics.Debug.WriteLine("Path: " + AppDomain.CurrentDomain.BaseDirectory);

                System.Diagnostics.Debug.WriteLine("IMAGE: " + pstringImage);

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
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pstringImage.Contains(FileTypePrefixPng))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (pstringImage.Contains(FileTypePrefixGif))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
            catch
            {
                pclsResponse.Code = 5;
                pclsResponse.Message = "Error handling picture";
                pclsResponse.Success = false;
            }

        }
        public void updateDiskImage(int pintDiskId, string pstringImage, ref clsResponse pclsResponse)
        {
            try
            {

                if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/")) //directory does not exist
                {
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/");
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/");
                }

                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".jpg")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".jpg");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".png")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".png");
                }
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".gif")) //directory does not exist
                {
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".gif");
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
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (pstringImage.Contains(FileTypePrefixPng))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
                if (pstringImage.Contains(FileTypePrefixGif))
                {
                    image.Save(AppDomain.CurrentDomain.BaseDirectory + "/Data/Disks/Images/" + pintDiskId.ToString() + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
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
