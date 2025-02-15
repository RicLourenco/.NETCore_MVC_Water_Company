﻿namespace NETCore_MVC_Water_Company.Web.Data
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
    using Microsoft.EntityFrameworkCore;

    public class SeedDb
    {
        readonly DataContext _context;
        readonly IUserHelper _userHelper;
        readonly IApiHelper _apiHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper,
            IApiHelper apiHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _apiHelper = apiHelper;
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
                await AddStep(0, 0.3f);
                await AddStep(5, 0.5f);
                await AddStep(10, 0.8f);
                await AddStep(15, 1.2f);

                await _context.SaveChangesAsync();
            }

            if (!_context.Cities.Any())
            {
                await GetAPICitiesAsync();
            }

            var user = await _userHelper.GetUserByEmailAsync("ricardo.pinto.lourenco@formandos.cinel.pt");

            if (user == null)
            {
                user = new User
                {
                    FirstNames = "Ricardo Filipe",
                    LastNames = "Pinto Lourenço",
                    BirthDate = Convert.ToDateTime(DateTime.ParseExact("14-05-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                    Email = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    UserName = "ricardo.pinto.lourenco@formandos.cinel.pt",
                    PhoneNumber = "987654321",
                    TIN = "271313862",
                    Address = "Rua das Flores, n.15, 3esq.",
                    DocumentNumber = "123456789",
                    Document = _context.Documents.FirstOrDefault(),
                    EmailConfirmed = true
                };

                var result = await _userHelper.AddUserAsync(user, "ABab12!?");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"An error occurred trying to create the default Admin Ricardo Lourenço in the seeder");
                }

                var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");

                if (!isInRole)
                {
                    await _userHelper.AddUserToRoleAsync(user, "Admin");
                }
            }
        }

        async Task GetAPICitiesAsync()
        {
            var cities = await _apiHelper.GetCitiesFromApiAsync();

            foreach(var city in cities)
            {
                await _context.Cities.AddAsync(city);
            }

            await _context.SaveChangesAsync();

            var duplicates = _context.Cities.GroupBy(c => c.Name).SelectMany(grp => grp.Skip(1));

            _context.Cities.RemoveRange(duplicates);

            await _context.SaveChangesAsync();
        }


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
