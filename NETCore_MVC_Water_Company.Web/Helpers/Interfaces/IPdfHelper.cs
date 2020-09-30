using Microsoft.AspNetCore.Mvc;
using NETCore_MVC_Water_Company.Web.Data.Entities;
using NETCore_MVC_Water_Company.Web.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IPdfHelper
    {
        /// <summary>
        /// Generate invoice pdf
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        Task<FileStreamResult> GenerateBillPDFAsync(Bill bill);

        /// <summary>
        /// Render body content
        /// </summary>
        /// <param name="text"></param>
        /// <param name="yPosition"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        PdfLayoutResult BodyContent(string text, float yPosition, PdfPage page);

        /// <summary>
        /// Render header content
        /// </summary>
        /// <param name="text"></param>
        /// <param name="yPosition"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        PdfLayoutResult HeaderPoints(string text, float yPosition, PdfPage page);

        /// <summary>
        /// Get water meter with user info for displaying in the pdf header
        /// </summary>
        /// <param name="waterMeterId"></param>
        /// <returns></returns>
        Task<WaterMeter> GetWaterMeterWithUserAsync(int waterMeterId);
    }
}
