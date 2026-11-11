# Views

An ASP.NET Core MVC project with practical examples from the views lesson.
All code and UI text are in English. No database or external packages are needed.

## Run in Visual Studio

1. Install Visual Studio 2022 17.8 or newer with the ASP.NET and web development workload and the .NET 8 SDK.
2. Open `Views.sln`.
3. Set `Views` as the startup project and run the `Views` profile.
4. The browser opens at `http://localhost:5102`.

From a terminal, run `dotnet run --project Views.csproj`.

## Examples

| Route | Example |
| --- | --- |
| `/` | Shared layout and navigation |
| `/Home/Data` | ViewData, ViewBag, typed view model and embedded partial |
| `/Home/Tuple` | Named tuple model |
| `/Home/Dynamic` | Dynamic access to a public model |
| `/Home/Anonymous` | Reflection over an anonymous model |
| `/Home/Syntax` | Razor expressions, conditions, switch, loops, functions and exception handling |
| `/Form` | Validated text, password, number, textarea, checkbox, radio and select inputs |
| `/Form/Profile` | POST, redirect, TempData and a success dialog |
| `/Form/People` | Binding and displaying a dictionary of people |
| `/Partial` | Fetch requests, live book search and student form returning partial views |
| `/Custom` | HTML rendered through a custom view engine |
| `/Custom/About` | Second custom HTML view |
| `/Custom/Contact` | Third custom HTML view |

`Views/_ViewStart.cshtml` selects the shared layout. `Views/_ViewImports.cshtml`
imports models and tag helpers. The layout supports Styles and Scripts sections
and injects `ITimeService`. The custom view engine only resolves three named
views in `CustomViews` and leaves all other views to Razor.

Forms validate on the server and use anti-forgery tokens. Passwords are only
validated and discarded. Submitted examples are not stored permanently.
