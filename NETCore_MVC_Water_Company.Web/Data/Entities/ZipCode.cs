using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class ZipCode : IEntity
    {
        public int Id { get; set; }


        [Required]
        [StringLength(4)]
        public string Code { get; set; }
    }
}
