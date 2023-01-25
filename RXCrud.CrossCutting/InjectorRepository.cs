using Microsoft.Extensions.DependencyInjection;
using RXCrud.Data.Repositories;
using RXCrud.Domain.Interfaces.Data;

namespace RXCrud.CrossCutting
{
    public static class InjectorRepository
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}