using Microsoft.AspNetCore.Mvc;

namespace MegaLanches.Controllers 
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}