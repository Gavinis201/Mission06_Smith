using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Smith.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Smith.Controllers
{
    public class HomeController : Controller
    {
        private MoviesFormContext _context;

        public HomeController(MoviesFormContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get2know()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MoviesForm()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movies());
        }

        [HttpPost]
        public IActionResult MoviesForm(Movies response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            ViewBag.Categories = _context.Categories.ToList();
            return View(response);
        }

        public IActionResult MoviesTable()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderBy(m => m.Title)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movieToEdit = _context.Movies
                .Include(m => m.Category)
                .Single(m => m.MovieId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("MoviesForm", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movies updatedMovie)
        {
            Console.WriteLine($"Edit POST - MovieId: {updatedMovie.MovieId}, Title: {updatedMovie.Title}");
            if (ModelState.IsValid)
            {
                var existingMovie = _context.Movies.Find(updatedMovie.MovieId);
                if (existingMovie != null)
                {
                    _context.Entry(existingMovie).CurrentValues.SetValues(updatedMovie);
                    _context.SaveChanges();
                    Console.WriteLine("Movie updated successfully.");
                    return RedirectToAction("MoviesTable");
                }
                Console.WriteLine("Movie not found.");
                return NotFound();
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("Edit Validation Errors: " + string.Join(", ", errors));
                ViewBag.Categories = _context.Categories.ToList();
                return View("MoviesForm", updatedMovie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _context.Movies
                .Include(m => m.Category)
                .SingleOrDefault(m => m.MovieId == id);
            if (movieToDelete == null)
            {
                return NotFound();
            }
            return View(movieToDelete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int MovieId)
        {
            var movieToDelete = _context.Movies
                .SingleOrDefault(m => m.MovieId == MovieId);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("MoviesTable");
        }
    } 
}