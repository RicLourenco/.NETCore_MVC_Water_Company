using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class WaterMeterRepository : GenericRepository<WaterMeter>, IWaterMeterRepository
    {
        readonly DataContext _context;

        public WaterMeterRepository(DataContext context): base(context)
        {
            _context = context;
        }

        public IQueryable GetWaterMetersWithBills()
        {
            return _context.WaterMeters
                .Include(w => w.Bills);
        }

        public async Task<WaterMeter> GetWaterMeterWithBillsAsync(int id)
        {
            return await _context.WaterMeters
                .Include(w => w.Bills)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
