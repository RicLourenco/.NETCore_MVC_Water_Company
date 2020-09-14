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
        IQueryable GetWaterMetersWithBills();

        Task<WaterMeter> GetWaterMeterWithBillsAsync(int id);
    }
}
