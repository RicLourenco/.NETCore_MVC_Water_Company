using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Client : IEntity
    {
        [Display(Name = "Client number")]
        public int Id { get; set; }


        public User User { get; set; }


        public IEnumerable<WaterMeter> WaterMeters { get; set; }
    }
}
