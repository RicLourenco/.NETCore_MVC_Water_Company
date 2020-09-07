using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class WaterMeter : IEntity
    {
        public int Id { get; set; }


        public string Address { get; set; }


        public float TotalConsumption { get; set; }


        public User User { get; set; }

        public Location Location { get; set; }
    }
}
