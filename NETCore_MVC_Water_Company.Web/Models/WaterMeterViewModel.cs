using Microsoft.AspNetCore.Mvc.Rendering;
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
        /// Is meter active
        /// </summary>
        [Required]
        [Display(Name = "Is meter active?")]
        public bool MeterState { get; set; }


        [Display(Name = "City")]
        public int CityId { get; set; }


        public IEnumerable<SelectListItem> Cities { get; set; }


        [Required]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }


        public string UserId { get; set; }
    }
}
