using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using CarTracker.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connect to database.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDatabaseContext>(options =>
{
	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.MapOpenApi();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapStaticAssets();

app.MapControllers();
app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();

app.Run("http://0.0.0.0:80");