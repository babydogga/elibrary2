using elibrary.Data;

using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class AutorzyController : Controller
    {
        private AppDbContext _context;

        public AutorzyController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Autorzy.ToList();

            return View(data);
        }

        //Get: Autorzy/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Autor objAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Autorzy.Add(objAutor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
           return View();
        }

    }
}
