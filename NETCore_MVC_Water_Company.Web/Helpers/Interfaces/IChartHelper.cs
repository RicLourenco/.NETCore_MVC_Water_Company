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
        /// <summary>
        /// Process x and y position for each element to display in the chart
        /// </summary>
        /// <param name="waterMeter"></param>
        /// <returns></returns>
        List<ChartDataViewModel> ProcessChartData(WaterMeter waterMeter);
    }
}
