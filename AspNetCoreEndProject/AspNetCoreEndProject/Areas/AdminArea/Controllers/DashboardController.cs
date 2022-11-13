using Microsoft.AspNetCore.Http;
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
        public ActionResult Index()
        {
            return View();
        }

    }
}
