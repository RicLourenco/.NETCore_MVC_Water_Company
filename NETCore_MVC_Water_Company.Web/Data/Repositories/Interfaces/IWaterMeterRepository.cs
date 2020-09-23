using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface IWaterMeterRepository : IGenericRepository<WaterMeter>
    {
        Task<WaterMeter> GetWaterMeterWithBillsAsync(int id);

        Task DeleteWaterMeterWithBills(WaterMeter waterMeter);

        Task<IQueryable<WaterMeter>> GetWaterMetersAsync(string userName);

        Task CreateWaterMeter(WaterMeter waterMeter, string userName);
    }
}
