using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        readonly DataContext _context;

        public ClientRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboWaterMeters(int clientId)
        {
            var client = _context.Clients.Find(clientId);
            var list = new List<SelectListItem>();
            if (client != null)
            {
                list = client.WaterMeters.Select(c => new SelectListItem
                {
                    Text = c.Id.ToString(),
                    Value = c.Id.ToString()
                }).OrderBy(l => l.Text).ToList();
            }

            list.Insert(0, new SelectListItem
            {
                Text = "Select a water meter...",
                Value = "0"
            });

            return list;
        }
    }
}
