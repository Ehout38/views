using Microsoft.AspNetCore.Mvc;
using Views.Models;
using Views.ViewModels;

namespace Views.Controllers;

public class FormController : Controller
{
    public IActionResult Index()
    {
        return View(new FormViewModel());
    }

    [HttpPost]
    public IActionResult Index(FormViewModel model)
    {
        string[] phones = ["iPhone", "Pixel", "Galaxy"];
        if (model.Phones.Any(phone => !phones.Contains(phone)))
            ModelState.AddModelError(nameof(model.Phones), "Select a listed phone.");
        if (!ModelState.IsValid)
        {
            ModelState.SetModelValue(nameof(model.Password), "", "");
            model.Password = "";
            return View(model);
        }
        model.Password = "";
        ModelState.Clear();
        return View("Result", model);
    }

    public IActionResult Profile()
    {
        return View(new ProfileViewModel());
    }

    [HttpPost]
    public IActionResult Profile(ProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        TempData["Message"] = $"Profile submitted for {model.Name}.";
        return RedirectToAction(nameof(Profile));
    }

    public IActionResult People()
    {
        return View(new Dictionary<int, Person>
        {
            [10] = new Person { Id = 10, Name = "Alex", Age = 22 },
            [20] = new Person { Id = 20, Name = "Sam", Age = 23 },
            [30] = new Person { Id = 30, Name = "Taylor", Age = 24 }
        });
    }

    [HttpPost]
    public IActionResult People(Dictionary<int, Person> peopleDictionary)
    {
        if (peopleDictionary.Count != 3)
            ModelState.AddModelError("", "Submit all three people.");
        if (!ModelState.IsValid)
            return View(peopleDictionary);
        return View("PeopleResult", peopleDictionary);
    }
}
