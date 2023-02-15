using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecipeBookCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace RecipeBookCRUD.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.Recipes = _context.Recipes.Include(r=>r.Creator).ToList();
        ViewBag.Chefs = _context.Chefs.ToList();
        return View();
    }

    [HttpGet("/recipes/new")]
    public ViewResult New()
    {
        ViewBag.Chefs = _context.Chefs.Where(c=>c.ChefId > 0).ToList();
        foreach(Chef chef in ViewBag.Chefs)
        {
            Console.WriteLine(chef.FirstName);
        }
        return View();
    }

    [HttpGet("/recipes/{id}")]
    public ViewResult ViewOne(int id)
    {
        Recipe? r = _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
        return View(r);
    }

    [HttpGet("/recipes/{id}/edit")]
    public ViewResult Edit(int id)
    {
        ViewBag.Chefs = _context.Chefs.Where(c=>c.ChefId > 0).ToList();
        Recipe? r = _context.Recipes.Include(r=>r.Creator).FirstOrDefault(r => r.RecipeId == id);
        return View(r);
    }

    [HttpPost("/recipes/{id}/update")]
    public IActionResult Update(Recipe newR, int id)
    {
        Recipe? oldR = _context.Recipes.SingleOrDefault(r=>r.RecipeId == id);
        if (ModelState.IsValid)
        {
            oldR!.Name = newR.Name;
            oldR.Tastiness = newR.Tastiness;
            oldR.Calories = newR.Calories;
            oldR.Description = newR.Description;
            oldR.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Edit", oldR);
        }
    }

    [HttpPost("recipes/{id}/destroy")]
    public IActionResult Destroy(int id)
    {
        Recipe? r = _context.Recipes.SingleOrDefault(r => r.RecipeId == id);
        _context.Recipes.Remove(r!);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpPost("/recipes/create")]
    public IActionResult Create(Recipe newRecipe)
    {
        Console.WriteLine("============================\nMade it into Create Action\n================================");
        Console.WriteLine("Foreign Key: "+newRecipe.Name);
        Console.WriteLine("Foreign Key: "+newRecipe.ChefId);
        Console.WriteLine("Creator: "+newRecipe.Creator);
        if (ModelState.IsValid)
        {
            Console.WriteLine("============================\nMade it past Validation\n================================");

            _context.Add(newRecipe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            Console.WriteLine("============================\nValidation Failure\n================================");
            return View("New", newRecipe);
        }
    }

    [HttpGet("/chefs/new")]
    public ViewResult NewChef()
    {
        return View();
    }

    [HttpPost("/chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("NewChef", newChef);

        }
    }

    [HttpPost("/chefs/{Id}/destroy")]
    public IActionResult ChefDestroy(int Id)
    {
        Chef? c = _context.Chefs.SingleOrDefault(e=>e.ChefId == Id);
        _context.Remove(c!);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
