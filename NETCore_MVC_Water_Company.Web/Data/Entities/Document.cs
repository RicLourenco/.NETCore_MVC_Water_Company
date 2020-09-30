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


        /// <summary>
        /// Document name
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Document name")]
        public string Name { get; set; }


        /// <summary>
        /// Associated user
        /// </summary>
        public IEnumerable<User> User { get; set; }
    }
}
