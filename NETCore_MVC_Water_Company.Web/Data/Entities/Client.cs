namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;


    public class Client : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "First names")]
        [Required]
        public string FirstNames { get; set; }

        [Display(Name = "Last names")]
        [Required]
        public string LastNames { get; set; }

        //TODO: Client must be 18 years old, or older
        [Display(Name = "Date of birth")]
        [Required]
        public DateTime BirthDate { get; set; }

        //TODO: Missing tables: gender, locations, documenttype

        public User User { get; set; }
    }
}
