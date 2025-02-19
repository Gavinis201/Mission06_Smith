using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Smith.Models;

namespace Mission06_Smith.Controllers;

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
        return View();
    }

    [HttpPost]
    public IActionResult MoviesForm(Movies response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        
        return View("Confirmation", response);
    }

   
}