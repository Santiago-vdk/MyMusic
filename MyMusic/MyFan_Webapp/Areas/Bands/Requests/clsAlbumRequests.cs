using DTO;
using MyFan_Webapp.Areas.Bands.Models;
using MyFan_Webapp.Requests;
using System.Net.Http;
using System.Threading.Tasks;
using Utility;

namespace MyFan_Webapp.Areas.Bands.Requests
{
    public class clsAlbumRequests
    {
        public static async Task<string> PostAlbumForm(clsAlbum form, int Id)
        {
            Serializer serializer = new Serializer();
            string RequestBody = serializer.Serialize(form);
            clsRequest RequestObject = new clsRequest("-1", Id, RequestBody);

            HttpResponseMessage request = await clsHttpClient.getClient().PostAsJsonAsync("users/bands/" + Id + "/albums", RequestObject);
            if (request.IsSuccessStatusCode)
            {
                string response = request.Content.ReadAsStringAsync().Result;
                return await Task.FromResult(response);
            }
            else
            {
                return await Task.FromResult("Unexpected error ocurred");
            }

        }
    }
}