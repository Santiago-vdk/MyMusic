using System.Web.Mvc;

namespace MyFan_Webapp.Areas.Bands
{
    public class BandsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bands";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bands_default",
                "Bands/{userId}/{controller}/{action}",
                defaults: new { controller = "Bands", action = "Index" },
                constraints: new { userId = @"\d+" }
            );

            context.MapRoute(
                "Bands_Edit",
                "Bands/{userId}/profile/edit",
                defaults: new { controller = "Bands", action = "Edit" }
            );

            context.MapRoute(
                "Bands_Albums",
                "Bands/{userId}/albums/{albumId}",
                defaults: new { controller = "Albums", action = "Index" }
            );

        }
    }
}