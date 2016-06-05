using DataAccess;
using DTO;
using BusinessLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class FacadeBL
    {
        public clsAlbumBL AlbumBL { get; set; }
        public clsBandBL BandBL { get; set; }
        public clsDiskBL DiskBL { get; set; }
        public clsEventBL EventBL { get; set; }
        public clsFanBL FanBL { get; set; }
        public clsNewBL NewBL { get; set; }
        public clsUserBL UserBL { get; set; }


        public void getFanForm()
        {
            FanBL.getForm();
        }
        public static void Main()
        {
            

            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
