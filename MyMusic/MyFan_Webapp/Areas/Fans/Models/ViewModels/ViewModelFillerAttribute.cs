using MyFan_Webapp.Areas.Fans.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans.Models.ViewModels
{
    public class ViewModelFillerAttribute : ActionFilterAttribute

    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var model = filterContext.Controller.ViewData.Model as IndexViewModel;
            IndexViewModel model = new IndexViewModel();
            // Apply changes to the view model object

            HttpContext context = HttpContext.Current;
            model.Username = context.Session["Username"].ToString();
            model.Id = (int) context.Session["Id"];

             var result = GetBands(model.Id);
             model.Bands = result.Result;

            // base.OnActionExecuting(filterContext);
        }



        public async Task<List<clsBands>> GetBands(int Id)
        {
            
            string response = await clsFanRequests.GetFanBands(Id);
            return clsDataParser.parseFanBands(response);


        }

    }


}