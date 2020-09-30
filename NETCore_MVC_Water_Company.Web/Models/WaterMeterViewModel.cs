using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class WaterMeterViewModel
    {
        public int MeterId { get; set; }


        [Required]
        public string Address { get; set; }


        /// <summary>
        /// Is meter active
        /// </summary>
        [Required]
        [Display(Name = "Is meter active?")]
        public bool MeterState { get; set; }


        [Display(Name = "Total consumption")]
        [DisplayFormat(DataFormatString = "{0:F} m³")]
        public float TotalConsumption { get; set; }


        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        public int CityId { get; set; }


        public IEnumerable<SelectListItem> Cities { get; set; }


        [Required]
        [Display(Name = "Zip code")]
        [RegularExpression(@"^\d{4}(-\d{3})?$", ErrorMessage = "Invalid zip code")]
        public string ZipCode { get; set; }


        public string UserId { get; set; }


        public DateTime CreationDate { get; set; }
    }
}
