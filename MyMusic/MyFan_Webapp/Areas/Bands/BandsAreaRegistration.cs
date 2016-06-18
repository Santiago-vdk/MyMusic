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
                "Bands/{userId}/{action}",
                defaults: new { controller = "Bands", action = "Index" },
                constraints: new { userId = @"\d+" },
                namespaces: new[] { "MyFan_Webapp.Areas.Bands.Controllers" }
            );


            context.MapRoute(
                "Bands_Albums",
                "Bands/{userId}/{controller}/{action}",
           
                namespaces: new[] { "MyFan_Webapp.Areas.Bands.Controllers" }
            );

           /* context.MapRoute(
                "Bands_Edit",
                "Bands/{userId}/profile/edit",
                defaults: new { controller = "Bands", action = "Edit" },
                namespaces: new[] { "MyFan_Webapp.Areas.Bands.Controllers" }
            );*/

            
        }
    }
}