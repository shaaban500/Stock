using Microsoft.EntityFrameworkCore;
using Stock.Application.Services.Products;
using Stock.Application.Services.ProductStores;
using Stock.Application.Services.store;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.Services.ProductStores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Infrastructure.Contexts;
using Stock.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(
    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IStoresService, storeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStoreService, ProductStoreService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews().AddNToastNotifyNoty(new NToastNotify.NotyOptions()
{
    ProgressBar = true,
    Timeout = 3000,
    Theme = "metroui",
});


var app = builder.Build();

    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
if (!app.Environment.IsDevelopment())
{
}

app.UseNToastNotify();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
