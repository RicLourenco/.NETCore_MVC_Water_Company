using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Models;
using Org.BouncyCastle.Bcpg;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class WaterMeter : IEntity
    {
        [Display(Name = "Serial number")]
        public int Id { get; set; }


        /// <summary>
        /// Water meter address
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }


        /// <summary>
        /// Total accumulated consumption from day 1
        /// </summary>
        [Required]
        [Display(Name = "Total consumption")]
        [DisplayFormat(DataFormatString = "{0:F} m³")]
        public float TotalConsumption { get; set; }


        /// <summary>
        /// Is meter active
        /// </summary>
        [Required]
        [Display(Name = "Is meter active?")]
        public bool MeterState { get; set; }


        /// <summary>
        /// Associated city id
        /// </summary>
        public int CityId { get; set; }


        /// <summary>
        /// Associated city
        /// </summary>
        public City City { get; set; }


        /// <summary>
        /// Water meter zip code
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Zip code")]
        [RegularExpression(@"^\d{4}(-\d{3})?$", ErrorMessage = "Invalid zip code")]
        public string ZipCode { get; set; }


        /// <summary>
        /// Water meter creation date
        /// </summary>
        [Display(Name = "Registration date")]
        public DateTime CreationDate { get; set; }


        /// <summary>
        /// Associated bills
        /// </summary>
        public ICollection<Bill> Bills { get; set; }


        /// <summary>
        /// Associated user
        /// </summary>
        public User User { get; set; }


        /// <summary>
        /// Bill chart data to display
        /// </summary>
        [NotMapped]
        public List<ChartDataViewModel> ChartData { get; set; }
    }
}