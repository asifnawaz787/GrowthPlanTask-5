using Asif_nawaz_Assessment_5_Growth_Plan.Models;
using WebApplication9.ProblemFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(static (option) =>
{
});
builder.Services.AddSingleton<IHasher, HashKey>();
builder.Configuration.GetSection("AdminSafeList").Get<AdminSafeList>();
var app = builder.Build();

//app.UseMiddleware<AdminSafeListMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
