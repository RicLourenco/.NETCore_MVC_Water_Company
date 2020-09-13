﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NETCore_MVC_Water_Company.Web.Data.Entities;

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
        [Display(Name = "Meter active?")]
        public bool MeterState { get; set; }


        public City City { get; set; }


        [Required]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }


        //TODO: check later
        public IEnumerable<Bill> Bills { get; set; }
    }
}