using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Fans
{
    public class FansAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Fans";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Fans_default",
                "Fans/{userId}/{action}",
                defaults: new { controller = "Fans", action = "Index" },
                constraints: new { userId = @"\d+" }
            );

            context.MapRoute(
                "Fans_Edit",
                "Fans/{userId}/profile/edit",
                defaults: new { controller = "Fans", action = "Edit" }
            );

            context.MapRoute(
                "Fans_Bands",
                "Fans/{userId}/bands/{bandId}",
                defaults: new { controller = "Bands", action = "Index" }
            );

            context.MapRoute(
                "Fans_BandsContent",
                "Fans/{userId}/bands/{bandId}/{controller}/{id}",
                defaults: new { controller = "Bands", action = "Index" } //Hmmmmm?????
            );






        }
    }
}