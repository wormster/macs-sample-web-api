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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


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

//builder.Services.Configure<ConfigOptions>(
//    builder.Configuration.GetSection(ConfigOptions.ConnectionStrings));
//builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
//builder.Services.AddScoped<IPersonRepository>(serviceProvider => new PersonRepository(
//    serviceProvider.GetRequiredService<IOptions<ConfigOptions>>().Value.MacsConnectionString
//));
//builder.Services.AddScoped(typeof(IPersonHandler), typeof(PersonHandler));
builder.Services.AddScoped<IPersonHandler, PersonHandler>();
//builder.Services.AddScoped<IAddressRepository>(serviceProvider => new AddressRepository(
//    serviceProvider.GetRequiredService<IOptions<ConfigOptions>>().Value.MacsConnectionString
//));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IPersonHandler, PersonHandler>();

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
