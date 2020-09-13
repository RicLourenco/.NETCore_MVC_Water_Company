using System;
using System.ComponentModel.DataAnnotations;

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
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal FinalValue { get; set; }


        [Required]
        public DateTime MonthYear { get; set; }


        //TODO: check later
        public WaterMeter WaterMeter { get; set; }


        //TODO: Maybe necessary to calculate finalprice
        public Step Step { get; set; }
    }
}
