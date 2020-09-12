namespace NETCore_MVC_Water_Company.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using NETCore_MVC_Water_Company.Web.Helpers;
    using System;
    using NETCore_MVC_Water_Company.Web.Helpers.Classes;
    using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        readonly DataContext _context;
        readonly IUserHelper _userHelper;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public UserHelper UserHelper { get; }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("ricardo.pinto.lourenco@formandos.cinel.pt");

            if(user == null)
            {
                user = new User
                {
                    FirstNames = "Ricardo",
                    LastNames = "Lourenço",
                    BirthDate = Convert.ToDateTime(DateTime.ParseExact("14-05-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                    Email = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    UserName = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    PhoneNumber = "914776731"
                };

                var result = await _userHelper.AddUserAsync(user, "NTIyiit1234!");

                if(!result.Succeeded)
                {
                    throw new InvalidOperationException($"An error occurred trying to create the default Admin Ricardo Lourenço in the seeder");
                }
            }

            /*
            if(!_context.Cities.Any())
            {
                AddLocation("Lisboa");
                AddLocation("Porto");
                AddLocation("Aveiro");
                AddLocation("Algarve");
                AddLocation("Alentejo");
                await _context.SaveChangesAsync();
            }
            */
        }

        /*
        void AddLocation(string name)
        {
            _context.Cities.Add(new City
            {
                Name = name
            });
        }
        */
    }
}
