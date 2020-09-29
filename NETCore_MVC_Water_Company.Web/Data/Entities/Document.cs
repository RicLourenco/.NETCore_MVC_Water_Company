using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class Document : IEntity
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public IEnumerable<User> User { get; set; }
    }
}
