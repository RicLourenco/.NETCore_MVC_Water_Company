using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Document : IEntity
    {
        public int Id { get; set; }


        [Required]
        [Display(Name = "Document type")]
        public string DocumentType { get; set; }
    }
}
