﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class City : IEntity
    {
        public int Id { get; set; }


        [Required]
        public string CityName { get; set; }


        [Required]
        public IEnumerable<ZipCode> ZipCodes { get; set; }
    }
}
