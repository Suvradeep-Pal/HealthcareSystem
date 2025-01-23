using Business.AccesLayer;
using Business.AccessLayer;
using Business.AccessLayer.Interface;
using Data.AccessLayer;
using Data.AccessLayer.Interface;
using Data.AccessLayer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<HealthcareContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

builder.Services.AddScoped<IPatientDA, PatientDA>();
builder.Services.AddScoped<IPatientBC, PatientBC>();
builder.Services.AddScoped<IDoctorDA, DoctorDA>();
builder.Services.AddScoped<IDoctorBC, DoctorBC>();
builder.Services.AddScoped<IPrescriptionDA, PrescriptionDA>();
builder.Services.AddScoped<IPrescriptionBC, PrescriptionBC>();

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
