using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IApiHelper
    {
        /// <summary>
        /// Fetch cities from a JSON api
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<City>> GetCitiesFromApiAsync(); 
    }
}
