using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class WaterMeter : IEntity
    {
        public int Id { get; set; }


        [Required]
        public string Street { get; set; }


        public string DoorNumber { get; set; }


        public string Floor { get; set; }


        /// <summary>
        /// Total accumulated consumption from day 1
        /// </summary>
        [Required]
        [Display(Name = "Total consumption")]
        public float TotalConsumption { get; set; }


        /// <summary>
        /// Is meter active
        /// </summary>
        public bool MeterState { get; set; }


        public User User { get; set; }



        public City City { get; set; }


        //TODO: concat the first 4 digits from the list of zipcodes in the selected city 
        //with the last 3 digits inserted by the user in the view
        [Required]
        [Display(Name = "Full zip code")]
        public string ZipCode { get; set; }
    }
}