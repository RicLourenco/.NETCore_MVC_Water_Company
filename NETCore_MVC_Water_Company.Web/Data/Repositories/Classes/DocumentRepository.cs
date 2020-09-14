using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Classes
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        readonly DataContext _context;

        public DocumentRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetComboDocuments()
        {
            var list = _context.Documents.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()

            }).OrderBy(l => l.Text).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "Select an identification document...",
                Value = "0"
            });

            return list;
        }

        public async Task<Document> GetDocumentAsync(int id)
        {
            return await _context.Documents.FindAsync(id);
        }
    }
}
