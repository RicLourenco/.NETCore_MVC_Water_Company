using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
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
        readonly IUserHelper _userHelper;

        public WaterMeterRepository(
            DataContext context,
            IBillRepository billRepository,
            IUserHelper userHelper)
            : base(context)
        {
            _context = context;
            _billRepository = billRepository;
            _userHelper = userHelper;
        }

        public async Task DeleteWaterMeterWithBills(WaterMeter waterMeter)
        {
            foreach(var bill in waterMeter.Bills)
            {
                await _billRepository.DeleteAsync(bill);
            }

            await DeleteAsync(waterMeter);
        }

        public async Task<WaterMeter> GetWaterMeterWithBillsAsync(int id, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null)
            {
                return null;
            }

            if (await _userHelper.IsUserInRoleAsync(user, "Admin")
                || await _userHelper.IsUserInRoleAsync(user, "Employee"))
            {
                return await _context.WaterMeters
                .Include(w => w.Bills)
                .Include(w => w.City)
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
            }

            return await _context.WaterMeters
                .Include(w => w.Bills)
                .Include(w => w.City)
                .Where(w => w.Id == id && w.User == user)
                .FirstOrDefaultAsync();
        }

        public async Task<IQueryable<WaterMeter>> GetWaterMetersAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if(user == null)
            {
                return null;
            }

            if(await _userHelper.IsUserInRoleAsync(user, "Admin")
                || await _userHelper.IsUserInRoleAsync(user, "Employee"))
            {
                return _context.WaterMeters
                    .Include(w => w.User)
                    .Include(w => w.Bills)
                    .Include(w => w.City);
            }

            return _context.WaterMeters
                    .Include(w => w.User)
                    .Include(w => w.Bills)
                    .Include(w => w.City)
                    .Where(w => w.User == user);
        }
    }
}
