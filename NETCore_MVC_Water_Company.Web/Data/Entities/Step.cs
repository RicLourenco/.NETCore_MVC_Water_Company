using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Step : IEntity
    {
        public int Id { get; set; }


        public byte StepNumber { get; set; }


        public float MaximumConsumption { get; set; }


        public float Price { get; set; }
    }
}
