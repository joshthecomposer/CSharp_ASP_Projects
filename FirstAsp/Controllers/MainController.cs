using Microsoft.AspNetCore.Mvc;

namespace FIRSTASP.Controllers;
public class MainController
{
    [HttpGet("")]
    public string Index()
    {
        return "Hello world from MainController!";
    }
    [HttpGet("/user/more")]
    public string More()
    {
        return "This is user/more page!";
    }

    [HttpGet("/login")]
    public string Login()
    {
        return "This is login page!";
    }

    [HttpPost("/submission")] //won't work, because I have no way to post.
    public string Submission()
    {
        return "This is submission page!";
    }

    [HttpGet("/greet/{name}/{id}")]
    public string Greeting(string name, int id)
    {
        return $"Hello {name} at id {id}!";
    }
}