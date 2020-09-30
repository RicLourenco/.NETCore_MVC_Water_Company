using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETCore_MVC_Water_Company.Web.Models;

namespace NETCore_MVC_Water_Company.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "RICARDO FILIPE PINTO LOURENÇO\nCINEL: CET.TPSI.46\nv1.0 30/09/2020";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "My contact: 914776731\nricardo.pinto.lourenco@formandos.cinel.pt";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
