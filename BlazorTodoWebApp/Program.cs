using BlazorTodoWebApp.Data.Models;
using BlazorTodoWebApp.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

string rootDirectory = Environment.CurrentDirectory;
string errorDirectory = rootDirectory + "\\Errors\\";
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(errorDirectory + "log.text", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging();
});

builder.Services.AddScoped<TodoService>();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
