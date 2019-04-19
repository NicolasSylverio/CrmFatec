using Crm.Domain.Interfaces.Repositories;
using Crm.Infra.Data.Contexto;
using Crm.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Crm.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Infra - Data
            services.AddScoped<CrmContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}