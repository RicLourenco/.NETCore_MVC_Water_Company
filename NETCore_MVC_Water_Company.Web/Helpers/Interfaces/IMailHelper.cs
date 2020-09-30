using Microsoft.AspNetCore.Mvc;
using NETCore_MVC_Water_Company.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IMailHelper
    {
        /// <summary>
        /// Send e-mail
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        void SendMail(string to, string subject, string body);

        /// <summary>
        /// Send invoice e-mail
        /// </summary>
        /// <param name="to"></param>
        /// <param name="model"></param>
        /// <param name="invoice"></param>
        void SendInvoiceMail(string to, BillViewModel model, FileStreamResult invoice);
    }
}
