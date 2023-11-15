using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FrontCrossyTec
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de servicios, incluido el registro de IHttpContextAccessor.
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app)
        {
            // Configuración del middleware y rutas de la aplicación.
        }
    }
}

