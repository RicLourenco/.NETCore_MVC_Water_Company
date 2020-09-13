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
        [Required]
        [Display(Name = "First names")]
        public string FirstNames { get; set; }


        [Required]
        [Display(Name = "Last names")]
        public string LastNames { get; set; }


        [Display(Name = "Full name")]
        public string FullName { get => $"{FirstNames} {LastNames}"; }


        [Required]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }


        [Required]
        public byte Gender { get; set; }


        [Required]
        [Display(Name = "Identification document")]
        public Document Document { get; set; }


        [Required]
        [Display(Name = "Document number")]
        public string DocumentNumber { get; set; }


        [Required]
        [Display(Name = "Tax identitfication number")]
        public string TIN { get; set; }
    }
}