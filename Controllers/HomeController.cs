using Microsoft.AspNetCore.Mvc;
using Views.Models;
using Views.ViewModels;

namespace Views.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Data()
    {
        ViewData["Welcome"] = "Hello from ViewData";
        ViewData["Person"] = new Person { Name = "Alex", Age = 24 };
        ViewBag.Countries = new List<string> { "Canada", "Italy", "Japan" };
        return View(new IndexViewModel
        {
            Title = "Strongly typed model",
            Values = ["Read", "Practice", "Build"]
        });
    }

    public IActionResult Tuple()
    {
        return View((Name: "Alex", Age: 24));
    }

    public IActionResult Dynamic()
    {
        return View(new Person { Name = "Sam", Age = 25 });
    }

    public IActionResult Anonymous()
    {
        return View(new { Name = "Taylor", Age = 26 });
    }

    public IActionResult Syntax()
    {
        return View();
    }

    public IActionResult Error()
    {
        Response.StatusCode = 500;
        return View();
    }
}
