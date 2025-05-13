var builder = WebApplication.CreateBuilder(args);

// Přidej podporu pro MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Umožni servírování statických souborů (např. CSS z wwwroot)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Nastav výchozí trasu na Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
