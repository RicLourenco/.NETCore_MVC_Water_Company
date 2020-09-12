using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class StepRepository : GenericRepository<Step> , IStepRepository
    {
        readonly DataContext _context;

        public StepRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
