﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using MimeKit;
using NETCore_MVC_Water_Company.Web.Helpers.Interfaces;
using NETCore_MVC_Water_Company.Web.Models;
using Syncfusion.EJ2.Linq;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace NETCore_MVC_Water_Company.Web.Helpers.Classes
{
    public class MailHelper : IMailHelper
    {
        readonly IConfiguration _configuration;

        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string to, string subject, string body)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = subject;

            var bodybuilder = new BodyBuilder
            {
                HtmlBody = body
            };

            message.Body = bodybuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(smtp, int.Parse(port), false);
                client.Authenticate(from, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendInvoiceMail(string to, BillViewModel model, FileStreamResult invoice)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to));
            message.Subject = "Ricardo's Water Company Invoice";

            System.Net.Mail.Attachment file = new System.Net.Mail.Attachment(invoice.FileStream, invoice.ContentType);

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $"Invoice n.{model.Id} for the following date: {model.MonthYear}"
            };

            bodyBuilder.Attachments.Add(invoice.FileDownloadName, file.ContentStream);

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect(smtp, int.Parse(port), false);
                client.Authenticate(from, password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
