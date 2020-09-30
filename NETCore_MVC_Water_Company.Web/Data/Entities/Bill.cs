using System;
using System.ComponentModel.DataAnnotations;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Bill : IEntity
    {
        [Display(Name = "Bill number")]
        public int Id { get; set; }


        /// <summary>
        /// Is bill payed
        /// </summary>
        [Display(Name = "Is bill payed?")]
        public bool PaymentState { get; set; }


        /// <summary>
        /// Consumption for specific month
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [DisplayFormat(DataFormatString = "{0:F} m³")]
        [Range(0, 9999, ErrorMessage = "Must be a positive number")]
        public float Consumption { get; set; }

        /// <summary>
        /// Price to apply in bill
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price")]
        public float FinalValue { get; set; }


        /// <summary>
        /// Date of bill
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM//yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MonthYear { get; set; }


        /// <summary>
        /// Associated water meter id
        /// </summary>
        public int WaterMeterId { get; set; }


        /// <summary>
        /// Associated water meter
        /// </summary>
        public WaterMeter WaterMeter { get; set; }
    }
}
