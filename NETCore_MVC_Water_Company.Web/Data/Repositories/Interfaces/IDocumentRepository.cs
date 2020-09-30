using Microsoft.AspNetCore.Mvc.Rendering;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Data.Repositories.Interfaces
{
    public interface IDocumentRepository : IGenericRepository<Document>
    {
        /// <summary>
        /// Get documents combobox
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectListItem> GetComboDocuments();

        /// <summary>
        /// Get specific document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Document> GetDocumentAsync(int id);
    }
}
