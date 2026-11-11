using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers;

public class CustomController : Controller
{
    public IActionResult Index()
    {
        return View("Custom/Index");
    }

    public IActionResult About()
    {
        return View("Custom/About");
    }

    public IActionResult Contact()
    {
        return View("Custom/Contact");
    }
}
