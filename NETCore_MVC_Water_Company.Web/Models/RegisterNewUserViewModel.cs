using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "First names")]
        public string FirstNames { get; set; }


        [Required]
        [Display(Name = "Last names")]
        public string LastNames { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }


        [Required]
        [MaxLength(100, ErrorMessage = "The {0} can contain a maximum of {1} characters.")]
        public string Address { get; set; }


        [Display(Name = "Phone number")]
        [MaxLength(20, ErrorMessage = "The {0} only can contain {1} characters.")]
        public string PhoneNumber { get; set; }

        //[Required]
        public byte Gender { get; set; }


        [Display(Name = "Identification document")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a document")]
        public int DocumentId { get; set; }


        public IEnumerable<SelectListItem> Documents { get; set; }


        [Required]
        [Display(Name = "Identification document number")]
        public string DocumentNumber { get; set; }


        [Required]
        public string Password { get; set; }


        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }


        [Required]
        [Display(Name = "Tax identification number")]
        public string TIN { get; set; }
    }
}
