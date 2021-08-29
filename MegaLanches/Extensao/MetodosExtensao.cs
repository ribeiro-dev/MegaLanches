using System;
using MegaLanches.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MegaLanches.Extensao
{
    public static class MetodosExtensao
    {
        public static IHost CreateAdminRole(this IHost host)
        {
            // Cria escopo para chamar serviços de escopo
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var configuration = services.GetRequiredService<IConfiguration>();
                    // chama o método para criar os perfis
                    // e atribuir o perfil Admin ao superusuário
                    SeedData.CreateRoles(serviceProvider, configuration).Wait();
                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "Ocorreu um erro na criação dos perfis dos superusuários");
                }
            }
            return host;
        }
    }
}