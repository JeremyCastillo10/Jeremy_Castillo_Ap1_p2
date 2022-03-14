using Microsoft.AspNetCore.Components.Web;
using Blazored.Toast;
using Jeremy_Castillo_Ap1_p2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Jeremy_Castillo_Ap1_p2.BLL;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddBlazoredToast();

//Aqui inyecto DbContext
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))
);


builder.Services.AddTransient<ProductosBLL>();

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
