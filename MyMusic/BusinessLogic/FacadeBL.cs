using DataAccess;
using DTO;
using BusinessLogic.FanBusinessLogic;
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
        public clsBandBL BandBL { get; set; }
        public clsDiskBL DiskBL { get; set; }
        public clsEventBL EventBL { get; set; }
        clsFanBL FanBL = new clsFanBL();
        public clsNewBL NewBL { get; set; }
        public clsUserBL UserBL { get; set; }


        public string getFanForm()
        {
            return FanBL.getForm();
        }

        public string createFan(string pstringData)
        {
            return FanBL.createFan(pstringData);
        }

    }
}
