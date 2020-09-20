using Microsoft.AspNetCore.Mvc;
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
        readonly IBillRepository _billRepository;

        public WaterMeterRepository(
            DataContext context,
            IBillRepository billRepository)
            : base(context)
        {
            _context = context;
            _billRepository = billRepository;
        }

        public async Task DeleteWaterMeterWithBills(WaterMeter waterMeter)
        {
            foreach(var bill in waterMeter.Bills)
            {
                await _billRepository.DeleteAsync(bill);
            }

            await DeleteAsync(waterMeter);
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
