using elibrary.Data;
using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class WydawnictwaController : Controller
    {
        private AppDbContext _context;

        public WydawnictwaController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Wydawnictwa.ToList();

            return View(data);
        }

        //Get: Wydawnictwa/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Wydawnictwo objWydawnictwo)
        {
            if (ModelState.IsValid)
            {
                _context.Wydawnictwa.Add(objWydawnictwo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
