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

        // GET: Biblioteki/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var biblioteka = _context.Biblioteki.FirstOrDefault(a => a.Id == id);
            if (biblioteka == null)
            {
                return NotFound();
            }
            return View(biblioteka);
        }

        // GET: Biblioteki/Delete

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var biblioteka = _context.Biblioteki.Find(Id);
                if (biblioteka != null)
                {
                    var bibliotekaView = new Biblioteka()
                    {
                        Id = biblioteka.Id,
                        LogoBib = biblioteka.LogoBib,
                        NameBib = biblioteka.NameBib,
                        DescBib = biblioteka.DescBib

                    };
                    return View(bibliotekaView);
                }
                else
                {
                    TempData["errorMessage"] = $"Autor details not available for the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        // POST: Biblioteki/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Biblioteka model)
        {
            try
            {
                var biblioteka = _context.Biblioteki.FirstOrDefault(x => x.Id == model.Id);
                if (biblioteka != null)
                {
                    _context.Biblioteki.Remove(biblioteka);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Biblioteka została usunięta!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Biblioteka details not available for the Id: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(model);
            }
        }

        // GET: Biblioteki/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var biblioteka = _context.Biblioteki.FirstOrDefault(a => a.Id == id);
            if (biblioteka == null)
            {
                return NotFound();
            }
            return View(biblioteka);
        }

        // POST: Biblioteki/Edit
        [HttpPost]
        public IActionResult Edit(Biblioteka objBiblioteka)
        {
            if (ModelState.IsValid)
            {
                _context.Biblioteki.Update(objBiblioteka);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
