using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IChartHelper
    {
        List<ChartDataViewModel> ProcessChartData(WaterMeter waterMeter);
    }
}
