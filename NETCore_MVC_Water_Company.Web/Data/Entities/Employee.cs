using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    //ENTITY NOT CURRENTLY IN USE
    public class Employee : IEntity
    {
        [Display(Name = "Contract number")]
        public int Id { get; set; }


        public User User { get; set; }


        public string IBAN { get; set; }
    }
}
