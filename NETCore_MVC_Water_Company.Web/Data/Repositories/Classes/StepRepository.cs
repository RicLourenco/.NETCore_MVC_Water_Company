using Microsoft.AspNetCore.Identity.UI.Pages.Account.Manage.Internal;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Get steps ordered by minimum consumption
        /// </summary>
        /// <returns></returns>
        public IQueryable GetStepsOrdered()
        {
            return  _context.Steps
                .OrderBy(s => s.MinimumConsumption);

        }

        /// <summary>
        /// Insert new step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public async Task InsertStepAsync(Step step)
        {
            var result = await _context.Steps
                .Where(s => s.MinimumConsumption == step.MinimumConsumption && s.Id != step.Id)
                .FirstOrDefaultAsync();

            if(result == null)
            {
                await CreateAsync(step);
            }
        }

        /// <summary>
        /// Delete step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public async Task DeleteStepAsync(Step step)
        {
            if(step.MinimumConsumption != 0)
            {
                await DeleteAsync(step);
            }
        }


        /// <summary>
        /// Update step
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public async Task UpdateStepAsync(Step step)
        {
            var result = await _context.Steps
                .Where(s => s.MinimumConsumption == step.MinimumConsumption && s.Id != step.Id)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                result = await _context.Steps.AsNoTracking().FirstOrDefaultAsync();

                if (result.Id == step.Id)
                {
                    step.MinimumConsumption = 0;
                    await UpdateAsync(step);
                }
                else
                {
                    await UpdateAsync(step);
                }

            }
        }

        /// <summary>
        /// Calculate final price for bills
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        public float CalculateFinalPrice(float consumption)
        {
            var steps = _context.Steps.OrderByDescending(s => s.MinimumConsumption).ToList();

            float finalPrice = 0;

            foreach(var step in steps)
            {
                while (consumption >= step.MinimumConsumption)
                {
                    finalPrice += (step.Price * 0.01f);

                    consumption -= 0.01f;
                }
            }

            return finalPrice;
        }
    }
}
