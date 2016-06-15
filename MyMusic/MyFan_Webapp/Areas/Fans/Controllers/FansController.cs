using MyFan_Webapp.Areas.Fans.Models;
using MyFan_Webapp.Areas.Fans.Requests;
using MyFan_Webapp.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Controllers
{
    public class FansController : Controller
    {
        public async Task<ActionResult> Index(int userId)
        {
            if (Sessions.isAuthenticated(Request, Session))
            {
                int sessionRol = Int32.Parse(Session["rol"].ToString());
                if (!Sessions.isFan(sessionRol))
                {
                    return View("~/Views/Login/Index.cshtml");
                }
            }
            //[Bandas,Posts]
            List<string> response = await clsFanRequests.GetFanProfile(userId);
      
            //Hubo error
            if (!ErrorParser.parse(response[0]).Equals("") || !ErrorParser.parse(response[1]).Equals(""))
            {
                ViewBag.Message = "Fuck my life...";
            }

            VMFanProfile profile = DataParser.parseFanProfile(response);

            return View(profile);
        }

        public ActionResult Picture(string userName)
        {
            System.Diagnostics.Debug.WriteLine("getting picture for " + userName);
            string s = "iVBORw0KGgoAAAANSUhEUgAAABgAAAASCAIAAADOjonJAAAACXBIWXMAAAsTAAALEwEAmpwYAAACcklEQVR42pVUy05UQRSs07fvvc5lGEadIQgEDD6IEDUmosQYt8pC/R39Gvf+grhzTcJ+CD7CJMDwknnc269yMfIaRKV2nfSprlOnTksgrfORAggRBEIEAsFloJTSNvgPn3/cGUtnxrKrV3SSRBBeikhE0jTVNGplbWd51b58WFucrY5WklKiI+Eg1ekjz7AAIKlDxP3DotHs7Oz3vm91lh7VJ2vZcCnSkRzfGyg+DZJKKQBaAp31nXbe68inTtHcbL9evDE3XakOxUmshOGEa5Dj90MkAWiQsI7G5S60crPSNdt7vVePx57NX69X0yzVIuFiywgISZIaALynNXCwFvvGmtx8POhubLaXno5P1EvlUhzrC50m+26KJgBrYT18ABEEbWttbpY7prl5+Ob5xNz0SLUca61Ot0hC+nJEBBqgBgkfxDr4cGxpYWSnsKvdvN3ae7tQe3K7nGmofinIE+9FIhUqwzJU0QTgHKyBC6c1B9DlJm/3dje+bKV7WUyICHnGHoGoOJ2aHHn3XhOEc7TuiIgAEvoy8+mw88I3ptgqWATx54IlFEqUUEf9qQU6L9bCs686pa2iO++bi75RD+0UJiCYC7wWjcRZEhoEnIfzsF6RJRQ1HC749Tm/UUUvpg2A/VOEjoLtrPcENAXinRgXuyJjMcnWAtduht0hFIre/SXU/XUVGB9AahBiXGI7Jde+G5oP+LUWDhMxgSz+tWsCQKkskKRmYMZ8NBzcc41bbFaQx7CeCANCzsmSfmugA0hopTE7ntw/+FmzkrEWoT8d/ucXEiVJOj4hUSTG2r31b8V2C/C4HARgQDRUv1a5OfMLsQpx+LS8fvQAAAAASUVORK5CYII=";
            //data:image/png;base64,

            byte[] data = Convert.FromBase64String(s);
     

            return File(data, "image/png");


        }

        public new ActionResult Profile(int userId)
        {
            System.Diagnostics.Debug.WriteLine("check profile from " + userId);
            return View();
        }

        public ActionResult Edit()
        {
            System.Diagnostics.Debug.WriteLine("Edit Profile");
            return View();
        }
    }
}