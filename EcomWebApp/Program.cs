using EcomWebApp.Contexts;
using EcomWebApp.Helpers.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EcomWebApp.Models.Identity;
using EcomWebApp.Helpers.Repos.IdentityRepo;
using EcomWebApp.Helpers.Repos.ProductRepo;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>(); //new ShowcaseService()
//builder.Services.AddDbContext<ProductsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
builder.Services.AddDbContext<ContactFormContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MainDb")));

//Services
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<TagService>();
builder.Services.AddScoped<ProductTagService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ShoppingCartService>();
//Repos
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<ProductCategoryRepo>();
builder.Services.AddScoped<ProductRepo>();
builder.Services.AddScoped<ProductTagRepo>();
builder.Services.AddScoped<TagRepo>();

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

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".EcomWebApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDistributedMemoryCache();

builder.Services.AddHttpContextAccessor();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication(); // added this one
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
