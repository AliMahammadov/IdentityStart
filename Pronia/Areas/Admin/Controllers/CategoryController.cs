using Microsoft.AspNetCore.Mvc;
using Pronia.DAL;
using Pronia.Models;

namespace Pronia.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
         readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            return View(_context.categories.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
               
            }
            _context.categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Category category= _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof (Index));
        }

        public IActionResult Update(int? id)
        {
            if (id is null)

            {
                return BadRequest();
            }
            Category category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
                return View(category);


        }
        [HttpPost]
        public IActionResult Update(int? id,Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null|| id!=category.Id)
            {
                return BadRequest();
            }
            Category existCategory = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            existCategory.Name=category.Name;
            existCategory.ImgUrl=category.ImgUrl;
            _context.SaveChanges();
           
            return RedirectToAction(nameof(Index));
        }


    }

    
}
