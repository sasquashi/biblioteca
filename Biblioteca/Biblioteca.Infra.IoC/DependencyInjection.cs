﻿using Biblioteca.Application.Services;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Biblioteca.Infra.Data.Repositories;
using jsreport.AspNetCore;
using jsreport.Local;    
using jsreport.Binary;   
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
            services.AddScoped<IFormaCompraRepository, FormaCompraRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<IHistoricoVendaRepository, HistoricoVendaRepository>();
            services.AddScoped<IHistoricoAcaoRepository, HistoricoAcaoRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();

            services.AddScoped<LivroService>();
            services.AddScoped<AutorService>();
            services.AddScoped<AssuntoService>();
            services.AddScoped<VendaService>();
            services.AddScoped<FormaCompraService>();
            services.AddScoped<FormaPagamentoService>();
            services.AddScoped<HistoricoVendaService>();
            services.AddScoped<HistoricoAcaoService>();
            services.AddScoped<RelatorioService>();

            services.AddJsReport(new jsreport.Local.LocalReporting()
                .UseBinary(jsreport.Binary.JsReportBinary.GetBinary())
                .AsUtility()
                .Create());

            return services;
        }
    }
}