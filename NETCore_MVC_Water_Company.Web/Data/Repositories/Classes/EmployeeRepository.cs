//using NETCore_MVC_Water_Company.Web.Data.Entities;
//using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
//using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
//{
//    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
//    {
//        readonly DataContext _context;

//        readonly IUserHelper _userHelper;

//        public EmployeeRepository(DataContext context, IUserHelper userHelper) : base(context)
//        {
//            _context = context;
//            _userHelper = userHelper;
//        }

//        public async Task AddEmployeeWithUserAsync(Employee employee, string password)
//        {
//            await _userHelper.AddUserAsync(employee.User, password);
//            await CreateAsync(employee);
//        }
//    }
//}
