using EcomWebApp.Contexts;
using EcomWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>(); //new ShowcaseService()
builder.Services.AddDbContext<ProductsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));
builder.Services.AddDbContext<ContactFormContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ContactFormSql")));
builder.Services.AddScoped<ProductService>();







var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
