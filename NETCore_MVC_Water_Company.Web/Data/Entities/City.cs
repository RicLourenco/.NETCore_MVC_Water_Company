using Newtonsoft.Json;
using System;
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
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
