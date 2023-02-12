using Microsoft.AspNetCore.Mvc;

namespace FIRSTASP.Controllers;
public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.Name = "Joshua Wise";
        return View();
    }

    [HttpGet("user/more")]
    public RedirectToActionResult More()
    {
        return RedirectToAction("Index");
    }

    [HttpGet("login")]
    public string Login()
    {
        return "This is login page!";
    }

    [HttpPost("submission")] //won't work, because I have no way to post.
    public string Submission()
    {
        return "This is submission page!";
    }

    [HttpGet("greet/{name}/{id}")]
    public string Greeting(string name, int id)
    {
        return $"Hello {name} at id {id}!";
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, int Number)
    {
        Console.WriteLine($"Name : {Name}");
        Console.WriteLine($"Number : {Number}");
        return RedirectToAction("Index");
    }
}