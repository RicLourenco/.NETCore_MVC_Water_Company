namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        [Display(Name = "First names")]
        [Required]
        public string FirstNames { get; set; }


        [Display(Name = "Last names")]
        [Required]
        public string LastNames { get; set; }


        [Display(Name = "Full name")]
        public string FullName { get => $"{FirstNames} {LastNames}"; }


        //TODO: check leap year age
        [Display(Name = "Date of birth")]
        [Required]
        public DateTime BirthDate { get; set; }


        [Required]
        public byte Gender { get; set; }


        [Display(Name = "Identification document")]
        [Required]
        public Document Document { get; set; }
    }
}