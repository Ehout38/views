using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.ViewEngines;

public class CustomViewEngine : IViewEngine
{
    private readonly string folder;

    public CustomViewEngine(IWebHostEnvironment environment)
    {
        folder = System.IO.Path.Combine(environment.ContentRootPath, "CustomViews");
    }

    public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
    {
        return Find(viewName);
    }

    public ViewEngineResult GetView(string? executingFilePath, string viewPath, bool isMainPage)
    {
        return Find(viewPath);
    }

    private ViewEngineResult Find(string viewName)
    {
        if (!viewName.StartsWith("Custom/", StringComparison.Ordinal))
            return ViewEngineResult.NotFound(viewName, []);
        var name = viewName[7..];
        if (name is not ("Index" or "About" or "Contact"))
            return ViewEngineResult.NotFound(viewName, []);
        var path = System.IO.Path.Combine(folder, name + ".html");
        return File.Exists(path)
            ? ViewEngineResult.Found(viewName, new CustomView(path))
            : ViewEngineResult.NotFound(viewName, [path]);
    }
}
