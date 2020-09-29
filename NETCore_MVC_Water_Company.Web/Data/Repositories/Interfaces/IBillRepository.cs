using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
        Task<int> InsertBillAsync(BillViewModel model);

        Task<int> UpdateBillAsync(Bill bill);

        Task DeleteBillAsync(int id);

        Task<WaterMeter> GetWaterMeterWithBillsAsync(int id);
    }
}
