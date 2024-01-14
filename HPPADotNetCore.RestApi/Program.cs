using HPPADotNetCore.RestApi.EFDbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    //jsonOptions.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    //SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder()
    //{
    //    DataSource = ".", // server name
    //    InitialCatalog = "HPPADotNetCore", // database name
    //    UserID = "sa", // user name
    //    Password = "sa@123", // password
    //    TrustServerCertificate = true
    //};
    //opt.UseSqlServer(connectionStringBuilder.ConnectionString);
    string connectionString = builder.Configuration.GetConnectionString("DbConnection");
    opt.UseSqlServer(connectionString);
},
ServiceLifetime.Transient,
ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
