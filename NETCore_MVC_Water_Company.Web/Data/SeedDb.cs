using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data
{
    public class SeedDb
    {
        readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if(!_context.Locations.Any())
            {
                AddLocation("Lisboa");
                AddLocation("Porto");
                AddLocation("Aveiro");
                AddLocation("Algarve");
                AddLocation("Alentejo");
                await _context.SaveChangesAsync();
            }
        }

        void AddLocation(string name)
        {
            _context.Locations.Add(new Location
            {
                Name = name
            });
        }
    }
}
