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
        Task<FileStreamResult> GenerateBillPDFAsync(Bill bill);

        PdfLayoutResult BodyContent(string text, float yPosition, PdfPage page);

        PdfLayoutResult HeaderPoints(string text, float yPosition, PdfPage page);

        Task<WaterMeter> GetWaterMeterWithUserAsync(int waterMeterId);
    }
}
