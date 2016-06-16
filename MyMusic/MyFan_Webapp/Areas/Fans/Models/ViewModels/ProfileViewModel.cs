using DTO;
using MyFan_Webapp.Areas.Fans.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Models.ViewModels
{
    public class ProfileViewModel : IndexViewModel
    {
        public List<clsPublication> Posts { get; set; }

        public ProfileViewModel(int userId)
        {
            //Posts = new AwaitableDelegateCommand(LoadDataAsync);

           // var result = GetPosts(userId);
           // Posts = result.Result;
        }

        public async Task<List<clsPublication>> GetPosts(int userId)
        {
           
            string response = await clsFanRequests.GetFanPosts(userId);

            //Hubo error
            /* if (!clsErrorParser.parse(response[0]).Equals("") || !clsErrorParser.parse(response[1]).Equals(""))
             {
                 ViewPage.Message = "Fuck my life...";
             }*/
            System.Diagnostics.Debug.WriteLine(userId + " " + response);
            Posts = clsDataParser.parseFanPosts(response);
            System.Diagnostics.Debug.WriteLine(Posts[0]);
            return Posts;
            // profile.Username = Session["Username"].ToString();
            // return View(profile);


        }
    }
}