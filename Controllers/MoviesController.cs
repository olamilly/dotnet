using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieDB.Data;
using MovieDB.Models;

namespace MovieDB.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDBContext _db;
        public MoviesController(MovieDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Movies.ToList());
        }
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Movie NewMovie)
        {
            if (ModelState.IsValid)
            {
                if (!MovieExistByName(NewMovie.Title))
                {
                    _db.Movies.Add(NewMovie);
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Movie already exists in database");
                }
            }
            return View(NewMovie);
        }
        public IActionResult Delete (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var dmovie = _db.Movies.FirstOrDefault(m => m.MovieID == id);
            if (dmovie == null)
            {
                return NotFound();
            }
            return View(dmovie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed (int id)
        {
            var dmovie = _db.Movies.Find(id);
            _db.Movies.Remove(dmovie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dmovie = _db.Movies.Find(id);
            if (dmovie == null)
            {
                return NotFound();
            }
            return View(dmovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (int id, Movie movie)
        {
            if(id != movie.MovieID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Movies.Update(movie);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dmovie = _db.Movies.FirstOrDefault(m => m.MovieID == id);
            if (dmovie == null)
            {
                return NotFound();
            }
            return View(dmovie);
        }
        private bool MovieExistByName(string moviename)
        {
            return _db.Movies.Any(m => m.Title.ToLower() == moviename.ToLower());
        }
    }
}
