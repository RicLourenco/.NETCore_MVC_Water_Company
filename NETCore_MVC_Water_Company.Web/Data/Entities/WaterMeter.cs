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


        public int CityId { get; set; }


        public City City { get; set; }


        [Required]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        [Display(Name = "Registration date")]
        public DateTime CreationDate { get; set; }


        public ICollection<Bill> Bills { get; set; }


        public User User { get; set; }


        [NotMapped]
        public List<ChartDataViewModel> ChartData { get; set; }
    }
}