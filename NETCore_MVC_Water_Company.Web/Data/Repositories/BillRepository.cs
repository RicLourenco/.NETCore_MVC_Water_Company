using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories
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
