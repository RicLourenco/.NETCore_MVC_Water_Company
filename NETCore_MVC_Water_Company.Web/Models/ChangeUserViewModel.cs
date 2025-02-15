﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class ChangeUserViewModel
    {
        public string Id { get; set; }


        [Required]
        [Display(Name = "First names")]
        public string FirstNames { get; set; }


        [Required]
        [Display(Name = "Last names")]
        public string LastNames { get; set; }


        [MaxLength(100, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string Address { get; set; }


        [Required]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [MaxLength(15, ErrorMessage = "The field {0} only can contain {1} characters.")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Identification document")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a document")]
        public int DocumentId { get; set; }


        public IEnumerable<SelectListItem> Documents { get; set; }


        public string DocumentNumber { get; set; }


        [Required]
        [Display(Name = "Tax identitfication number")]
        [StringLength(9, ErrorMessage = "{0} must have 9 digits")]
        public string TIN { get; set; }
    }
}
