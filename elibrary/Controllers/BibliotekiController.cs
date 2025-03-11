using elibrary.Data;
using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class BibliotekiController : Controller
    {
        private AppDbContext _context;

        public BibliotekiController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Biblioteki.ToList();

            return View(data);
        }

        //Get: Biblioteki/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Biblioteka objBiblioteka)
        {
            if (ModelState.IsValid)
            {
                _context.Biblioteki.Add(objBiblioteka);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
