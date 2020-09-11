namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        DateTime _birthDate;


        [Display(Name = "First names")]
        [Required]
        public string FirstNames { get; set; }


        [Display(Name = "Last names")]
        [Required]
        public string LastNames { get; set; }


        [Display(Name = "Full name")]
        public string FullName { get => $"{FirstNames} {LastNames}"; }


        [Display(Name = "Date of birth")]
        [Required]
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if(DateTime.UtcNow.Year - value.Year >= 18 &&
                    DateTime.UtcNow.DayOfYear >= value.DayOfYear)
                {
                    _birthDate = value;
                }
            }
        }


        [Required]
        public byte Gender { get; set; }


        [Display(Name = "Identification document")]
        [Required]
        public Document DocumentType { get; set; }


        [Required]
        [Display(Name = "Document number")]
        public string DocumentNumber { get; set; }


        [Required]
        [Display(Name = "Expiration date")]
        public DateTime ExpirationDate { get; set; }
    }
}
