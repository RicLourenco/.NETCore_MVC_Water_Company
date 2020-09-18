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

        public IQueryable GetStepsOrdered()
        {
            return  _context.Steps
                .OrderBy(s => s.MinimumConsumption);

        }

        public async Task InsertStepAsync(Step step)
        {
            var result = await _context.Steps
                .Where(s => s.MinimumConsumption == step.MinimumConsumption)
                .FirstOrDefaultAsync();

            if(result == null)
            {
                await CreateAsync(step);
            }
        }

        public async Task DeleteStepAsync(Step step)
        {
            if(step.MinimumConsumption != 0)
            {
                await DeleteAsync(step);
            }
        }
    }
}
