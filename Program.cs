using Microsoft.AspNetCore.Mvc;
using Views.Services;
using Views.ViewEngines;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(options =>
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));
builder.Services.AddTransient<ITimeService, SimpleTimeService>();
builder.Services.Configure<MvcViewOptions>(options =>
    options.ViewEngines.Insert(0, new CustomViewEngine(builder.Environment)));

var app = builder.Build();
if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
