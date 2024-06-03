using StationUI.Components;
using Microsoft.EntityFrameworkCore;
using Station.Persistance;
using Station.ServicesInterfaces;
using Station.Services;
using MudBlazor.Services;
using Newtonsoft.Json;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<StationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));
    
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
builder.Services.AddScoped<IDriverRep, DriverRep>();
builder.Services.AddScoped<ICustomerRep, CustomerRep>();
builder.Services.AddScoped<IBookingRep, BookingRep>();
builder.Services.AddScoped<IJourneyRep, JourneyRep>();
builder.Services.AddScoped<IVehicalRep, VehicalRep>();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
