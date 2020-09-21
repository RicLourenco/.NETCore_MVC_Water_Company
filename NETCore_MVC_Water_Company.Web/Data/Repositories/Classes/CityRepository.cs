using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        readonly DataContext _context;

        public CityRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetCitiesOrdered() =>
            _context.Cities.OrderBy(c => c.Name);

        public IEnumerable<SelectListItem> GetComboCities()
        {
            var list = _context.Cities.Select(
                c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Select a city...",
                Value = "0"
            });

            return list;
        }
    }
}
