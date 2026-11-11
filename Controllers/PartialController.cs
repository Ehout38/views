using Microsoft.AspNetCore.Mvc;
using Views.Models;

namespace Views.Controllers;

public class PartialController : Controller
{
    private static readonly string[] Books =
    [
        "The Hobbit",
        "The Little Prince",
        "Clean Code",
        "The Pragmatic Programmer"
    ];

    public IActionResult Index()
    {
        return View(new Student());
    }

    [HttpGet]
    public IActionResult GetBooks(string? query)
    {
        var books = Books.Where(book => string.IsNullOrWhiteSpace(query)
            || book.Contains(query.Trim(), StringComparison.OrdinalIgnoreCase)).ToList();
        return PartialView("_Books", books);
    }

    [HttpGet]
    public IActionResult Message()
    {
        return PartialView("_Message", "This partial was loaded without a page reload.");
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
        if (!ModelState.IsValid)
        {
            Response.StatusCode = 422;
            return PartialView("_StudentErrors");
        }
        return PartialView("_Student", student);
    }
}
