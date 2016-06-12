using DataAccess;
using DTO;
using BusinessLogic.FanBusinessLogic;
using BusinessLogic.BandBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Controllers;

namespace BusinessLogic
{
   public class FacadeBL
    {
        public clsAlbumBL AlbumBL { get; set; }
        public clsDiskBL DiskBL { get; set; }
        public clsEventBL EventBL { get; set; }
        clsFanBL FanBL = new clsFanBL();
        clsBandBL BandBL = new clsBandBL();
        public clsNewBL NewBL { get; set; }
        public clsUserBL UserBL { get; set; }


        public string getFanForm()
        {
            return FanBL.getForm();
        }
        public string getBandForm()
        {
            return BandBL.getForm();
        }


        public string createFan(string pstringRequest)
        {
            return FanBL.createFan(pstringRequest);
        }
        public string createBand(string pstringRequest)
        {
            return BandBL.createBand(pstringRequest);
        }

        public string login(string pstringRequest)
        {
            return UserBL.login(pstringRequest);
        }
        public string checkUsername(string pstringUsername)
        {
            return UserBL.checkUsername(pstringUsername);
        }

        public string checkHashtag(string pstringHashtag)
        {
            return BandBL.checkHashtag(pstringHashtag);
        }




    }
}
