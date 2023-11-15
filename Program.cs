using FrontCrossyTec.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http; // Asegúrate de incluir esta directiva

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ApiService>(client =>
{
    // Modificar esto a la dirección del puerto en el que está la base de datos
    client.BaseAddress = new Uri("https://localhost:7173/");
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // Ignorar errores de certificado SSL solo en desarrollo
    ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
});

// Configurar la sesión de usuario
builder.Services.AddSession(options =>
{
    // Configura las opciones de sesión aquí según tus necesidades
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Duración de la sesión
});

// Registra IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

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

// Agregar el middleware de sesión después de UseStaticFiles pero antes de UseRouting
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
