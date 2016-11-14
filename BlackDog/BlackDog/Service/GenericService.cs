using BlackDog.Service;
using SisGPC.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BlackDog.Models;
using System.Net.Http;
using BlackDog.Helpers;

[assembly: Dependency(typeof(GenericService))]
namespace BlackDog.Service
{
    public class GenericService : IGenericService
    {
        public async Task<List<PageModel>> GetAllPages()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "http://blackdog.azurewebsites.net/tables/gep_generic_page";
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                var result = await client.GetAsync(url);

                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    return JsonHelper<PageModel>.FromJSON_List(data);
                }
                else
                    return new List<PageModel>();
            }
        }

    }
}
