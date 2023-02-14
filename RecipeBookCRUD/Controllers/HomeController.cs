using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecipeBookCRUD.Models;

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
        List<Recipe> allRecipes = _context.Recipes.Where(r => r.RecipeId > 0).ToList();
        ViewBag.Recipes = allRecipes;
        return View();
    }

    [HttpGet("/recipes/new")]
    public ViewResult New()
    {
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
        Recipe? r = _context.Recipes.FirstOrDefault(r => r.RecipeId == id);
        return View(r);
    }

    [HttpPost("/recipes/{id}/update")]
    public IActionResult Update(Recipe newR, int id)
    {
        Recipe? oldR = _context.Recipes.SingleOrDefault(r=>r.RecipeId == id);
        if (ModelState.IsValid)
        {
            oldR!.Name = newR.Name;
            oldR.Chef = newR.Chef;
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
        if (ModelState.IsValid)
        {
            _context.Add(newRecipe);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            Console.WriteLine(newRecipe.Name);
            Console.WriteLine(newRecipe.Chef);
            Console.WriteLine(newRecipe.Calories);
            Console.WriteLine(newRecipe.Description);
            Console.WriteLine(newRecipe.Tastiness);
            Console.WriteLine("Couldn't create recipe");
            return View("New", newRecipe);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
