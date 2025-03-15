using elibrary.Data;

using elibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        //Post: Autorzy/Create
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

        // GET: Autorzy/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var autor = _context.Autorzy.FirstOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // GET: Autorzy/Delete

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var autor = _context.Autorzy.Find(Id);
                if (autor != null)
                {
                    var autorView = new Autor()
                    {
                        Id = autor.Id,
                        ProfilePictureURL = autor.ProfilePictureURL,
                        FullName = autor.FullName,
                        Bio = autor.Bio

                    };
                    return View(autorView);
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

       

        // POST: Autorzy/Delete
        [HttpPost]
        public IActionResult Delete(Autor model)
        {
            try
            {
                var autor = _context.Autorzy.FirstOrDefault(x => x.Id == model.Id);
                if (autor != null)
                {
                    _context.Autorzy.Remove(autor);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Autor został usunięty!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Autor details not available for the Id: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
