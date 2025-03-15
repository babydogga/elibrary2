using elibrary.Data;
using elibrary.Data.Enums;
using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void PopulateWydawnictwoList()
        {
            IEnumerable<SelectListItem> GetWydawnictwo =
                _context.Wydawnictwa.Select(i => new SelectListItem
                {
                    Text = i.NameWyd,
                    Value = i.Id.ToString()
                });

            ViewBag.Wydawnictwa = GetWydawnictwo;
        }
        public void PopulateWydawnictwoList2()
        {
            IEnumerable<SelectListItem> GetBiblioteka =
                _context.Biblioteki.Select(i => new SelectListItem
                {
                    Text = i.NameBib,
                    Value = i.Id.ToString()
                });

            ViewBag.Biblioteki = GetBiblioteka;
        }

        public void PopulateWydawnictwoList3()
        {
            IEnumerable<SelectListItem> ksiazkaCategories =
                Enum.GetValues(typeof(KsiazkaCategory))
        .Cast<KsiazkaCategory>().Select(e => new SelectListItem
        {
            Text = e.ToString(),
            Value = ((int)e).ToString()
        });

            ViewBag.KsiazkaCategories = ksiazkaCategories;
        }


        public IActionResult Index()
        {
            var allKsiazki = _context.Ksiazki
                .Include(n => n.Biblioteki)
                .Include(n => n.Wydawnictwa)
                .OrderBy(n => n.NameKs).ToList();
            return View(allKsiazki);
        }
        //GET: Ksiazki/Create
        public IActionResult Create()
        {
            PopulateWydawnictwoList();
            PopulateWydawnictwoList2();
            PopulateWydawnictwoList3();
            return View();
        }

        // POST: Ksiazki/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ksiazka objKsiazka)
        {
            if (ModelState.IsValid)
            {
                // Ensure the foreign keys are set correctly
                objKsiazka.Wydawnictwa = _context.Wydawnictwa.Find(objKsiazka.WydId);
                objKsiazka.Biblioteki = _context.Biblioteki.Find(objKsiazka.BibId);

                _context.Ksiazki.Add(objKsiazka);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            // Repopulate the dropdown lists in case of validation error
            PopulateWydawnictwoList();
            PopulateWydawnictwoList2();
            PopulateWydawnictwoList3();

            return View(objKsiazka);
        }

    }
}
