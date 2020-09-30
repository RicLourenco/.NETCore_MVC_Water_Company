namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [Required(ErrorMessage = "{0} are required")]
        [Display(Name = "First names")]
        public string FirstNames { get; set; }


        [Required(ErrorMessage = "{0} are required")]
        [Display(Name = "Last names")]
        public string LastNames { get; set; }


        [Display(Name = "Full name")]
        public string FullName { get => $"{FirstNames} {LastNames}"; }


        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        public int DocumentId { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Identification document")]
        public Document Document { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document number")]
        public string DocumentNumber { get; set; }


        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Tax identitfication number")]
        [StringLength(9, ErrorMessage = "{0} must have 9 digits")]

        public string TIN { get; set; }


        public string IBAN { get; set; }


        public ICollection<WaterMeter> WaterMeters { get; set; }
    }
}