using Microsoft.AspNetCore.Mvc;

// TODO: namespace.<projectname>.Controllers
public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }
}