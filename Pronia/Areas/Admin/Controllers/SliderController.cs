using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;
using Pronia.ViewModels;

namespace Pronia.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.OrderByDescending(s => s.Order));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateSliderVM sliderVM)
        {
            if (!ModelState.IsValid) return View();  //mocud deyilse getme

            IFormFile file = sliderVM.Image;
            if (!file.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Yuklediyiniz fayl shekil deyil");
                return View();
            }
            if (file.Length > 200 * 1024)
            {
                ModelState.AddModelError("Image", "Shekilin olcusu 200 kb-dan artiq ola bilmez");
                return View();
            }
            //string fileName = Guid.NewGuid() + (file.FileName.Length > 64 ? file.FileName.Substring(0,64) : file.FileName);
            string fileName = Guid.NewGuid() + file.FileName;
            using (var stream = new FileStream("C:\\Users\\User\\Desktop\\HomeWork\\BackEnd\\Pronia\\Pronia\\wwwroot\\assets\\images\\slider\\" + fileName, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Slider slider = new Slider { Description = sliderVM.Description, Order = sliderVM.Order, PrimaryTitle = sliderVM.PrimaryTitle, SecondaryTitle = sliderVM.SecondaryTitle, ImageUrl = fileName };
            if (_context.Sliders.Any(s => s.Order == slider.Order))
            {
                ModelState.AddModelError("Order", $"{slider.Order} sirasinda artiq slider movcuddur");
                return View();
            }
        CheckOrder:
            if (_context.Sliders.Any(s => s.Order == slider.Order))
            {
                slider.Order++;
                goto CheckOrder;
            }
            //while (_context.Sliders.Any(s => s.Order == slider.Order))
            //{
            //    slider.Order++;
            //}
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0) return BadRequest();
            Slider slider = _context.Sliders.Find(id);
            if (slider is null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(int id, Slider slider)
        {
            if (id == null || id == 0 || id != slider.Id || slider is null) return BadRequest();
            if (!ModelState.IsValid) return View();
            Slider anotherSlider = _context.Sliders.FirstOrDefault(s => s.Order == slider.Order);
            if (anotherSlider != null)
            {
                anotherSlider.Order = _context.Sliders.Find(id).Order;
            }
            Slider exist = _context.Sliders.Find(slider.Id);
            exist.Order = slider.Order;
            exist.Description = slider.Description;
            exist.PrimaryTitle = slider.PrimaryTitle;
            exist.SecondaryTitle = slider.SecondaryTitle;
            exist.ImageUrl = slider.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = _context.Sliders.Find(id);
            if (slider is null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
    
}
