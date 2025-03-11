using elibrary.Data;
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

        public async Task<IActionResult> Index()
        {
            var allKsiazki = await _context.Ksiazki.Include(n => n.Biblioteki).OrderBy(n => n.NameKs).ToListAsync();
            return View(allKsiazki);
        }
    }
}
