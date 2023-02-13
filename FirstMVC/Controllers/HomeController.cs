using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstMVC.Models;

namespace FirstMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.MyNum = 9;
        Friend friend = new Friend("Joshua", "Wise", "NYC", 32);
        return View(friend);
    }

    [HttpGet("second")]
    public ViewResult SecondPage()
    {
        return View();
    }
}
