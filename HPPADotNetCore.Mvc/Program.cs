using HPPADotNetCore.MvcApp.EFDbContext;
using HPPADotNetCore.MvcApp.RefitExamples1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DbConnection");
    options.UseSqlServer(connectionString);
},
ServiceLifetime.Transient,
ServiceLifetime.Transient);

#region Refit

builder.Services
	.AddRefitClient<IFamilyApi>()
	.ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetSection("RestApiUrl").Value!));

#endregion

#region HttpClient

//builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<HttpClient>(x => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("RestApiUrl").Value!)
});

#endregion

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
