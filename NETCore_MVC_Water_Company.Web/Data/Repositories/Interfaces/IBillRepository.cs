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
        /// <summary>
        /// Insert new bill
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<int> InsertBillAsync(BillViewModel model);

        /// <summary>
        /// Update bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        Task<int> UpdateBillAsync(Bill bill);

        /// <summary>
        /// Delete bill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteBillAsync(int id);

        /// <summary>
        /// Get water meter with bill included
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<WaterMeter> GetWaterMeterWithBillsAsync(int id);
    }
}
