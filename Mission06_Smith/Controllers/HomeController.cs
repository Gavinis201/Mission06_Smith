using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Smith.Models;

namespace Mission06_Smith.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Get2know()
    {
        return View();
    }
    
    public IActionResult MoviesForm()
    {
        return View();
    }

   
}