using Microsoft.AspNetCore.Mvc;
using System;
using Pronia.DAL;
using Pronia.ViewModels.Home;

namespace Pronia.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders=_context.Sliders,
                Brands=_context.Brands,
            };

            return View(homeVM);
        }

        
    }
}