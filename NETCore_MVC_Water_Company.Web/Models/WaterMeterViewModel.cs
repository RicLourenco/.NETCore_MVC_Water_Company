using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class WaterMeterViewModel
    {
        [Required]
        public string Address { get; set; }


        /// <summary>
        /// Total accumulated consumption from day 1
        /// </summary>
        [Required]
        [Display(Name = "Total consumption")]
        public float TotalConsumption { get; set; }


        /// <summary>
        /// Is meter active
        /// </summary>
        [Required]
        [Display(Name = "Is meter active?")]
        public bool MeterState { get; set; }


        public City City { get; set; }


        [Required]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }


        public string UserId { get; set; }
    }
}
