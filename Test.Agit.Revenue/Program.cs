using WebApplication2;
using WebApplication2.Context;
using WebApplication2.Interfaces;
using WebApplication2.Repository;

// using Test.Agit.Revenue.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var dbContextFactory = new DbContextFactory();
builder.Services.AddSingleton<ISalesOrderRepository>(new SalesOrderRepository(dbContextFactory));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();