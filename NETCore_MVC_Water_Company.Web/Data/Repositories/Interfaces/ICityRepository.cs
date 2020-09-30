using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface ICityRepository : IGenericRepository<City>
    {
        /// <summary>
        /// Get cities ordered by name
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetComboCities();

        /// <summary>
        /// Get cities combobox
        /// </summary>
        /// <returns></returns>
        IQueryable GetCitiesOrdered();
    }
}
