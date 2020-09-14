using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class ChangeUserViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstNames { get; set; }


        [Required]
        [Display(Name = "Last name")]
        public string LastNames { get; set; }


        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string Address { get; set; }


        [MaxLength(20, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "City")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a city")]
        public int DocumentId { get; set; }


        public IEnumerable<SelectListItem> Documents { get; set; }


        public string DocumentNumber { get; set; }


        [Required]
        [Display(Name = "Tax identitfication number")]
        public string TIN { get; set; }


        public string IBAN { get; set; }
    }
}
