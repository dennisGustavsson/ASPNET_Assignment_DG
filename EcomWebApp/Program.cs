using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using Microsoft.EntityFrameworkCore;
using EcomWebApp.Helpers.Repos;
using Microsoft.AspNetCore.Identity;
using EcomWebApp.Models.Identity;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>(); //new ShowcaseService()
builder.Services.AddDbContext<ProductsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDbSql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDbSql")));
builder.Services.AddDbContext<ContactFormContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ContactFormSql")));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<AddressService>();


builder.Services.AddIdentity<AppUser, IdentityRole>( x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

})  .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();



builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // added this one
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
