namespace NETCore_MVC_Water_Company.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using NETCore_MVC_Water_Company.Web.Data.Entities;
    using NETCore_MVC_Water_Company.Web.Helpers;
    using System;
    using System.Collections.Generic;
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

            var user = await _userHelper.GetUserByEmail("ricardo.pinto.lourenco@formandos.cinel.pt");

            if(user == null)
            {
                user = new User
                {
                    FirstName = "Ricardo",
                    LastName = "Lourenço",
                    Email = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    UserName = "RicLourenco",
                    PhoneNumber = "914776731"
                };

                var result = await _userHelper.AddUserAsync(user, "123456");

                if(!result.Succeeded)
                {
                    throw new InvalidOperationException($"An error occurred trying to create the default Admin RicLourenco in the seeder");
                }
            }

            //TODO: Check later if the locations will eventually need a User property

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
