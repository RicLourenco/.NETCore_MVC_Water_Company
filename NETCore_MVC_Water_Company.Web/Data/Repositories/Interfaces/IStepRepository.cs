using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        /// <summary>
        /// Get steps ordered by minimum consumption
        /// </summary>
        /// <returns></returns>
        IQueryable GetStepsOrdered();

        /// <summary>
        /// Insert new step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        Task InsertStepAsync(Step step);

        /// <summary>
        /// Delete step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        Task DeleteStepAsync(Step step);

        /// <summary>
        /// Update step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        Task UpdateStepAsync(Step step);

        /// <summary>
        /// Calculate final price for bills
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        float CalculateFinalPrice(float consumption);
    }
}
