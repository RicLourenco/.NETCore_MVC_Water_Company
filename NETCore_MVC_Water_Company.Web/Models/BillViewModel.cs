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
        public float Consumption { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        [Display(Name = "Price")]
        public float FinalValue { get; set; }


        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM//yyyy}")]
        public DateTime MonthYear { get; set; }


        public int WaterMeterId { get; set; }
    }
}
