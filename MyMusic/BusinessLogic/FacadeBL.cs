using DataAccess;
using DTO;
using BusinessLogic.FanBusinessLogic;
using BusinessLogic.BandBusinessLogic;
using BusinessLogic.UserBusinessLogic;
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

        clsEventBL EventBL = new clsEventBL();
        clsFanBL FanBL = new clsFanBL();
        clsBandBL BandBL = new clsBandBL();
        clsUserBL UserBL = new clsUserBL();
        clsNewBL NewBL = new clsNewBL();
        clsDiskBL DiskBL = new clsDiskBL();
        clsAlbumBL AlbumBL = new clsAlbumBL();

        public string getFanForm()
        {
            return FanBL.getForm();
        }
        public string getBandForm()
        {
            return BandBL.getForm();
        }
        public string getUserPicture(string pstringUserId)
        {
            return UserBL.getPicture(Int32.Parse(pstringUserId));
        }
        public string getNew(string pstringId)
        {
            return NewBL.getNew(pstringId);
        }
        public string getEvent(string pstringId)
        {
            return EventBL.getEvent(pstringId);
        }
        public string getPublications(int pintUserId, int pintOffset, int pintLimit)
        {
            return UserBL.getPublications(pintUserId, pintOffset, pintLimit);
        }
        public string getBands(int pintUserId, int pintOffset, int pintLimit)
        {
            return FanBL.getBands(pintUserId, pintOffset, pintLimit);
        }
        public string getSearchParams()
        {
            return UserBL.getSearchParams();
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
