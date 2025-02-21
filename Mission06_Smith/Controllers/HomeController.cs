using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Smith.Models;

namespace Mission06_Smith.Controllers
{
    // HomeController is responsible for handling requests related to the home page and movie form.
    public class HomeController : Controller
    {
        // MoviesFormContext is the database context used to interact with the Movies data.
        private MoviesFormContext _context;

        // Constructor that initializes the MoviesFormContext.
        // The 'temp' parameter is injected by dependency injection.
        public HomeController(MoviesFormContext temp)
        {
            _context = temp;
        }

        // Index action returns the default home page view.
        public IActionResult Index()
        {
            return View();
        }

        // Get2know action returns a page that likely introduces the site or provides information about it.
        public IActionResult Get2know()
        {
            return View();
        }

        // MoviesForm GET method returns the movie input form to the user.
        [HttpGet]
        public IActionResult MoviesForm()
        {
            return View();
        }

        // MoviesForm POST method handles the form submission, saves the movie to the database, 
        // and then shows a confirmation page with the submitted movie information.
        [HttpPost]
        public IActionResult MoviesForm(Movies response)
        {
            // Adds the submitted movie to the database and saves changes.
            _context.Movies.Add(response);
            _context.SaveChanges();

            // Returns a confirmation view, passing the submitted movie data.
            return View("Confirmation", response);
        }
    }
}