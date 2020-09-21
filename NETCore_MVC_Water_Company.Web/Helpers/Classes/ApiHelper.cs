using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace NETCore_MVC_Water_Company.Web.Helpers.Classes
{
    public class ApiHelper : IApiHelper
    {
        public async Task<IEnumerable<City>> GetCitiesFromApiAsync()
        {
            try
            {
                string urlBase = "https://gist.githubusercontent.com";

                string controller = "/tomahock/a6c07dd255d04499d8336237e35a4827/raw/861a6345dedc4292188bb71e39d0062318197fdf/distritos-concelhos-freguesias-Portugal.json";

                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                var response = await client.GetAsync(controller);

                var result = await response.Content.ReadAsStringAsync();

                var cities = JsonConvert.DeserializeObject<IEnumerable<City>>(result, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                return cities;
            }
            catch
            {
                return null;
            }
        }
    }
}
