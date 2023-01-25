using Microsoft.Extensions.DependencyInjection;
using RXCrud.Domain.Interfaces.Services;
using RXCrud.Service.Services;

namespace RXCrud.CrossCutting
{
    public static class InjectorService
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IEstadoService, EstadoService>();
            services.AddScoped<ICidadeService, CidadeService>();
        }
    }
}