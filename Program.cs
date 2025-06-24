using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Agrega soporte a controladores (obligatorio para usar [ApiController])
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

// Si usas autenticación JWT manual desde el controlador:
app.UseAuthentication();
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

app.Run();
