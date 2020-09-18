﻿using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface IStepRepository : IGenericRepository<Step>
    {
        IQueryable GetStepsOrdered();

        Task InsertStepAsync(Step step);

        Task DeleteStepAsync(Step step);
    }
}
