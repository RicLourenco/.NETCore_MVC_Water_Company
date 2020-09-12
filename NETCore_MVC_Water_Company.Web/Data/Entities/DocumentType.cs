using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Entities
{
    public class DocumentType : IEntity
    {
        public int Id { get; set; }

        public string DocumentName { get; set; }
    }
}
