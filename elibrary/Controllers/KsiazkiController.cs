using elibrary.Data;
using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class KsiazkiController : Controller
    {
        private readonly AppDbContext _context;

        public KsiazkiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allKsiazki =  _context.Ksiazki
                .Include(n => n.Biblioteki)
                .Include(n => n.Wydawnictwa)
                .OrderBy(n => n.NameKs).ToList();
            return View(allKsiazki);
        }
        //Get: Wydawnictwa/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ksiazka objKsiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Ksiazki.Add(objKsiazka);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
