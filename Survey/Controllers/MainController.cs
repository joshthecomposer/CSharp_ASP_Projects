using Microsoft.AspNetCore.Mvc;

namespace Survey.Controllers;
public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        return RedirectToAction("result", new { Name = Name, Location = Location, Language = Language, Comment = Comment});
    }
    [HttpGet("result")]
    public ViewResult Result(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        if (Comment == null) 
        {
            ViewBag.Comment = "No comment available";
        }
        else
        {
            ViewBag.Comment = Comment;
        }
        return View("result");
    }

}