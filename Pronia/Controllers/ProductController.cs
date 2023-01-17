using Microsoft.AspNetCore.Mvc;

namespace Pronia.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
