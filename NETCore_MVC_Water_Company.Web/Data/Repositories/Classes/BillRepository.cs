using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        readonly DataContext _context;

        public BillRepository( DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task InsertBillAsync(BillViewModel model)
        {
            var waterMeter = await GetWaterMeterWithBillsAsync(model.WaterMeterId);

            if(waterMeter == null)
            {
                return;
            }

            var result = await _context.Bills
                .Where(b => b.MonthYear == model.MonthYear
                && b.WaterMeterId == model.WaterMeterId)
                .FirstOrDefaultAsync();

            if(result == null)
            {
                waterMeter.Bills.Add(
                    new Bill
                    { 
                        Consumption = model.Consumption,
                        MonthYear = model.MonthYear,
                        FinalValue = model.FinalValue,
                        PaymentState = model.PaymentState
                    });
                _context.WaterMeters.Update(waterMeter);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> UpdateBillAsync(Bill bill)
        {
            var waterMeter = await _context.WaterMeters.Where(w => w.Bills.Any(b => b.Id == bill.Id)).FirstOrDefaultAsync();

            if(waterMeter == null)
            {
                return 0;
            }

            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return waterMeter.Id;
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
