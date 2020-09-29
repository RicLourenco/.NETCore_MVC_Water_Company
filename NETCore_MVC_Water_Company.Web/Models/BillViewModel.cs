using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class BillViewModel
    {
        [Display(Name = "Bill number")]
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
        [DisplayFormat(DataFormatString = "{0:F} m³")]
        [Range(0, 9999, ErrorMessage = "Must be a positive number")]
        public float Consumption { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price")]
        public float FinalValue { get; set; }


        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM//yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MonthYear { get; set; }


        public int WaterMeterId { get; set; }


        public DateTime DatePickerStartDate { get; set; }


        public DateTime DatePickerEndDate { get; set; }
    }
}
