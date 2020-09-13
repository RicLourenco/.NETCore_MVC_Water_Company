using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }


        public User User { get; set; }


        [Display(Name = "Contract number")]
        public string ContractNumber { get; set; }


        public string IBAN { get; set; }
    }
}
