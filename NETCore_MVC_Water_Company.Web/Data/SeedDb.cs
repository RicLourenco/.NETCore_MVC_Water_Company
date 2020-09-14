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
        //readonly IEmployeeRepository _employeeRepository;


        public SeedDb(DataContext context, IUserHelper userHelper/*, IEmployeeRepository employeeRepository*/)
        {
            _context = context;
            _userHelper = userHelper;
            //_employeeRepository = employeeRepository;
        }

        public UserHelper UserHelper { get; }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Documents.Any())
            {
                await AddDocument("Cartão de cidadão");
                await AddDocument("Carta de condução");
                await AddDocument("Bilhete de identidade");

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
                    Document = _context.Documents.FirstOrDefault(),
                    //WaterMeters = null
                };

                var result = await _userHelper.AddUserAsync(user, "%gURn73e");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException($"An error occurred trying to create the default Admin Ricardo Lourenço in the seeder");
                }

                //Employee employee = new Employee
                //{
                //    IBAN = "PT501234567890",
                //    User = new User
                //    {
                //        FirstNames = "Ricardo Filipe",
                //        LastNames = "Lourenço Pinto",
                //        BirthDate = Convert.ToDateTime(DateTime.ParseExact("14-05-1995", "dd-MM-yyyy", CultureInfo.InvariantCulture)),
                //        Email = "ricardo.pinto.lourenco@formandos.cinel.pt",
                //        UserName = "ricardo.pinto.lourenco@formandos.cinel.pt",
                //        PhoneNumber = "987654321",
                //        Gender = 0,
                //        TIN = "271313862",
                //        Address = "Rua das Flores, n.15, 3esq.",
                //        DocumentNumber = "123456789",
                //        Document = new Document
                //        {
                //            Name = "Cartão de cidadão"
                //        }
                //    }
                //};

                //await _employeeRepository.AddEmployeeWithUserAsync(employee, "NTIyiit1234!");
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
    }
}
