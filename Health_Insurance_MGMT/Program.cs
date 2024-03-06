using App.DataAccessLibrary;
using App.DataAccessLibrary.Infrastructure.IRepository;
using App.DataAccessLibrary.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddDbContext<HealthInsuranceMGMT>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
