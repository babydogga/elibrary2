using elibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Controllers
{
    public class WydawnictwaController : Controller
    {
        private readonly AppDbContext _context;

        public WydawnictwaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allWydawnictwa = await _context.Wydawnictwa.ToListAsync();
            return View(allWydawnictwa);
        }
    }
}
