var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews(options =>
{
    
    options.Filters.Add(new WebApplication8.Filters.ResponseTimeFilter());
});

var app = builder.Build();


app.UseMiddleware<WebApplication8.Middleware.LoggingMiddleware>();


app.UseExceptionHandler("/Error");

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();