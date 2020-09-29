using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Step : IEntity
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Minimum consumption")]
        [DisplayFormat(DataFormatString = "{0:F} m³")]
        [Range(0, 9999, ErrorMessage = "Must be a positive number")]
        public float MinimumConsumption { get; set; }


        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, 9999, ErrorMessage = "Must be a positive number")]
        public float Price { get; set; }
    }
}
