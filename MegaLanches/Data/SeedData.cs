using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MegaLanches.Data
{
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            // incluir perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // define os perfis em um array de strings
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            // percorre o array de strings
            // verifica se o perfil já existe
            foreach (var roleName in roleNames)
            {
                // cria perfis e os inclui no banco de dados
                var roleExists = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // cria um super usuário que pode manter a aplicação web
            var poweruser = new IdentityUser
            {
                // obtem o nome do arquivo de configuracao
                UserName = configuration.GetSection("UserSettings")["UserName"],
                Email = configuration.GetSection("UserSettings")["UserEmail"]
            };

            // obtém a senha do arquivo de configuração
            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];

            // verifica se existe um usuário com o email informado
            var user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                // cria o super usuario com os dados informados
                var createPowerUser = UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.IsCompletedSuccessfully)
                {
                    // atribui o usuário ao perfil Admin
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}