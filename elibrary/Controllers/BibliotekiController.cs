using elibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class BibliotekiController : Controller
    {
        private readonly AppDbContext _context;

        public BibliotekiController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allBiblioteki = await _context.Biblioteki.ToListAsync();
            return View(allBiblioteki);
        }
    }
}
