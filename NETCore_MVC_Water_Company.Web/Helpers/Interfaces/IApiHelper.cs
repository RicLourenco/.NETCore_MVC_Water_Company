using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IApiHelper
    {
        Task<IEnumerable<City>> GetCitiesFromApiAsync(); 
    }
}
