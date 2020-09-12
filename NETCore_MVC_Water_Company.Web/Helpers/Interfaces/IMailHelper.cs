using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore_MVC_Water_Company.Web.Helpers.Interfaces
{
    public interface IMailHelper
    {
        void SendMail(string to, string subject, string body);
    }
}
