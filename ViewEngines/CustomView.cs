using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Views.ViewEngines;

public class CustomView : IView
{
    public string Path { get; }

    public CustomView(string path)
    {
        Path = path;
    }

    public async Task RenderAsync(ViewContext context)
    {
        var content = await File.ReadAllTextAsync(Path, context.HttpContext.RequestAborted);
        await context.Writer.WriteAsync(content);
    }
}
