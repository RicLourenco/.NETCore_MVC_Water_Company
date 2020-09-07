using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Bill : IEntity
    {
        private string _monthYear;


        public int Id { get; set; }


        public float Consumption { get; set; }

        //TODO: Fix this
        public DateTime MonthYear
        {
            get
            {
                return Convert.ToDateTime(_monthYear);
            }
            set
            {
                _monthYear = value.ToString("MMMM-yyyy");
            }
        }


        public WaterMeter WaterMeter { get; set; }
    }
}
