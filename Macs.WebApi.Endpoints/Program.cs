using Macs.WebApi.DataAccess.Entities;
using Macs.WebApi.DataAccess.Repositories;
using Macs.WebApi.Endpoints.Options;
using Macs.WebApi.Handlers.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using System.Reflection;
using Macs.WebApi.DataAccess;
using Macs.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<MacsExceptionHandler>();

IConfigurationBuilder configBuilder = builder.Configuration;
configBuilder.Sources.Clear();
configBuilder.AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    //.AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables()
.AddCommandLine(args);

builder.Services.AddDbContext<MacsContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MacsDb")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IPersonHandler, PersonHandler>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(_ => {});

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
