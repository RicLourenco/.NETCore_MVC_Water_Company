using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Models
{
    public class ChangeUserRoleViewModel
    {
        public string UserId { get; set; }


        public string IBAN { get; set; }


        public string RoleName { get; set; }


        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
