using Microsoft.EntityFrameworkCore;
using Villa_Project.Context;
using Villa_Project.Services.Abstractions;
using Villa_Project.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VillaDbContext>(db =>
{
    db.UseSqlServer(builder.Configuration.GetConnectionString(name: "Default"));
});

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
