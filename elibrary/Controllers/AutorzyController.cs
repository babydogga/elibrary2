﻿using elibrary.Data;

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
        public IActionResult Delete(int id)
        {
            var autor = _context.Autorzy.Find(id);
            if (autor == null)
            {
                return NotFound();
            }

            var autorView = new Autor()
            {
                Id = autor.Id,
                ProfilePictureURL = autor.ProfilePictureURL,
                FullName = autor.FullName,
                Bio = autor.Bio
            };
            return View(autorView);
        }

        // POST: Autorzy/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return View(model);
            }
        }

        // GET: Autorzy/Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var autor = _context.Autorzy.FirstOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autorzy/Edit
        [HttpPost]
        public IActionResult Edit(Autor objAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Autorzy.Update(objAutor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
