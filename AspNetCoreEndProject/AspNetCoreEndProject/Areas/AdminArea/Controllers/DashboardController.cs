using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreEndProject.Areas.AdminArea.Controllers
{
    public class DashboardController : Controller
    {
        [Area("AdminArea")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
