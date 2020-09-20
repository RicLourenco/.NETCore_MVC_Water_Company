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
    using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;

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

            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Employee");
            await _userHelper.CheckRoleAsync("Client");

            if (!_context.Documents.Any())
            {
                await AddDocument("Cartão de cidadão");
                await AddDocument("Carta de condução");
                await AddDocument("Bilhete de identidade");

                await _context.SaveChangesAsync();
            }

            if (!_context.Steps.Any())
            {
                await AddStep(0, (float)0.3);
                await AddStep(5, (float)0.5);
                await AddStep(10, (float)0.8);
                await AddStep(15, (float)1.2);

                await _context.SaveChangesAsync();
            }

            var user = await _userHelper.GetUserByEmailAsync("ricardo.pinto.lourenco@formandos.cinel.pt");

            if (user == null)
            {
                user = new User
                {
                    FirstNames = "Ricardo Filipe",
                    LastNames = "Lourenço Pinto",
                    BirthDate = Convert.ToDateTime(DateTime.ParseExact("14-05-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                    Email = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    UserName = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    PhoneNumber = "987654321",
                    Gender = 0,
                    TIN = "271313862",
                    Address = "Rua das Flores, n.15, 3esq.",
                    DocumentNumber = "123456789",
                    Document = _context.Documents.FirstOrDefault()
                };

                var result = await _userHelper.AddUserAsync(user, "%gURn73e");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"An error occurred trying to create the default Admin Ricardo Lourenço in the seeder");
                }

                //var token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);

                //await _userHelper.ConfirmEmailAsync(user, token);

                var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

                if (!isInRole)
                {
                    await _userHelper.AddUserToRoleAsync(user, "Admin");
                }
            }

            //if (!_context.Cities.Any())
            //{
            //    await GetAPICitiesAsync();
            //    await _context.SaveChangesAsync();
            //}
        }

        //async Task GetAPICitiesAsync()
        //{

        //}

        async Task AddDocument(string name)
        {
            await _context.Documents.AddAsync( new Document{
                Name = name
            });
        }

        async Task AddStep(float minimumConsumption, float price)
        {
            await _context.Steps.AddAsync( new Step{
                MinimumConsumption = minimumConsumption,
                Price = price
            });
        }
    }
}
