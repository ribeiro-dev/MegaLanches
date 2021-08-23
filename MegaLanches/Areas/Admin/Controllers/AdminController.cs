using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MegaLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}