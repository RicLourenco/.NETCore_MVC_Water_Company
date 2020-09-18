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
        public float MinimumConsumption { get; set; }


        [Required]
        public float Price { get; set; }
    }
}
