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
        [Display(Name = "Is bill payed?")]
        public bool PaymentState { get; set; }


        /// <summary>
        /// Consumption for specific month
        /// </summary>
        [Required]
        public float Consumption { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Price")]
        public decimal FinalValue { get; set; }


        [Required]
        [Display(Name = "Bill date")]
        public DateTime MonthYear { get; set; }


        public WaterMeter WaterMeter { get; set; }


        public Step Step { get; set; }
    }
}
