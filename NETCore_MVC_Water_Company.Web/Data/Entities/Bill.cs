using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Bill : IEntity
    {
        public int Id { get; set; }


        /// <summary>
        /// Is bill payed
        /// </summary>
        [Required]
        public bool PaymentState { get; set; }


        /// <summary>
        /// Consumption for specific month
        /// </summary>
        [Required]
        public float Consumption { get; set; }


        [Required]
        public DateTime MonthYear { get; set; }


        public WaterMeter WaterMeter { get; set; }
    }
}
