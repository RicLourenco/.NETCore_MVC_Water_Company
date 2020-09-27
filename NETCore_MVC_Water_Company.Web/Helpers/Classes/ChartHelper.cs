using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Classes
{
    public class ChartHelper : IChartHelper
    {
        public List<ChartDataViewModel> ProcessChartData(WaterMeter waterMeter)
        {
            List<ChartDataViewModel> chartData = new List<ChartDataViewModel>();

            List<Bill> list = waterMeter.Bills.OrderByDescending(b => b.MonthYear).Take(12).ToList();

            list = list.OrderBy(b => b.MonthYear).ToList();

             for (int i = 0; i < list.Count; i++)
            {
                chartData.Add(new ChartDataViewModel { xValue = list[i].MonthYear.ToString("MM-yyyy"), yValue = Convert.ToDouble(list[i].Consumption) });
            }

            return chartData;
        }
    }
}
