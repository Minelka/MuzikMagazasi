using MuzikMagazasi.Context;
using MuzikMagazasi.MapperProfiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using MuzikMagazasi.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
//    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // Ýsteðe baðlý, güzel bir format için
//});

builder.Services.AddDbContext<MuzikMagazaDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MuzikMagazasiDb"));
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
