using Biblioteca.Application.Services;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Biblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BibliotecaDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<LivroService>();
            services.AddScoped<AutorService>();
            services.AddScoped<AssuntoService>();
            services.AddScoped<VendaService>();

            return services;
        }
    }
}