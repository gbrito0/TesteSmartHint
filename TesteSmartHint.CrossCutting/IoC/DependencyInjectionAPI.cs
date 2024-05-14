using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Application.Mapping;
using TesteSmartHint.Application.Services;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infrastructure.Context;
using TesteSmartHint.Infrastructure.Repositories;

namespace TesteSmartHint.CrossCutting.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            services.AddScoped<IPessoaRepository<Pessoa>, PessoaRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();                        
            services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
                        
            return services;
        }
    }
}
