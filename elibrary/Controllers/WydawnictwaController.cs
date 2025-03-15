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

        // GET: Wydawnictwa/Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var wydawnictwo = _context.Wydawnictwa.FirstOrDefault(a => a.Id == id);
            if (wydawnictwo == null)
            {
                return NotFound();
            }
            return View(wydawnictwo);
        }



        // GET: Wydawnictwa/Delete

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var wydawnictwo = _context.Wydawnictwa.Find(Id);
                if (wydawnictwo != null)
                {
                    var wydawnictwoView = new Wydawnictwo()
                    {
                        Id = wydawnictwo.Id,
                        WydPictureURL = wydawnictwo.WydPictureURL,
                        NameWyd = wydawnictwo.NameWyd,
                        DescWyd = wydawnictwo.DescWyd

                    };
                    return View(wydawnictwoView);
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
        // POST: Wydawnictwa/Delete
        [HttpPost]

        public IActionResult Delete(Wydawnictwo model)
        {
            try

            {
                var wydawnictwo = _context.Wydawnictwa.Find(model.Id);
                if (wydawnictwo != null)
                {
                    _context.Wydawnictwa.Remove(wydawnictwo);
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
