using FrontCrossyTec.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor(); // Agregar IHttpContextAccessor
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
