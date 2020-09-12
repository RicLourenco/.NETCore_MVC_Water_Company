using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        readonly DataContext _context;

        public BillRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
