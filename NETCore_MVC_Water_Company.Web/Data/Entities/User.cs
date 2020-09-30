namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Reflection.Metadata;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        /// <summary>
        /// User first names
        /// </summary>
        [Required(ErrorMessage = "{0} are required")]
        [Display(Name = "First names")]
        public string FirstNames { get; set; }


        /// <summary>
        /// User last names
        /// </summary>
        [Required(ErrorMessage = "{0} are required")]
        [Display(Name = "Last names")]
        public string LastNames { get; set; }


        /// <summary>
        /// User full name
        /// </summary>
        [Display(Name = "Full name")]
        public string FullName { get => $"{FirstNames} {LastNames}"; }


        /// <summary>
        /// User address
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        public string Address { get; set; }


        /// <summary>
        /// User birth date
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        /// <summary>
        /// Associated document id
        /// </summary>
        public int DocumentId { get; set; }


        /// <summary>
        /// Associated document
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Identification document")]
        public Document Document { get; set; }


        /// <summary>
        /// Associated document number
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document number")]
        public string DocumentNumber { get; set; }


        /// <summary>
        /// User tax identification number
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Tax identitfication number")]
        [StringLength(9, ErrorMessage = "{0} must have 9 digits")]
        public string TIN { get; set; }


        /// <summary>
        /// User international bank account number
        /// </summary>
        public string IBAN { get; set; }

        
        /// <summary>
        /// Associated water meters
        /// </summary>
        public ICollection<WaterMeter> WaterMeters { get; set; }


        /// <summary>
        /// Associated role name
        /// </summary>
        [NotMapped]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}