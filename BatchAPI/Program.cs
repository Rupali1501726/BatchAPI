using BatchAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BatchAPI.Controllers;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using System.Reflection;
using NLog;
using BatchAPI.AppLog;
using BatchAPI.Entities;
using BatchAPI.Services;
using System.ComponentModel.DataAnnotations;
using BatchAPI.Validator;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(CustomValidation));
});
builder.Services.AddControllers().AddFluentValidation(options =>
{
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BatchContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("AzureDBConnectionString")));
builder.Services.AddSingleton<ILog, BatchAPI.AppLog.NLog>();
builder.Services.AddScoped<Batch>(); 
builder.Services.AddScoped<Files>();
builder.Services.AddScoped<AddBatchResponse>();
builder.Services.AddScoped<IBatchServices,BatchServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//app.MapBatchEndpoints();

app.Run();
