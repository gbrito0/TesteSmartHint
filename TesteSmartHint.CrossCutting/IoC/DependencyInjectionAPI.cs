using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 29))));

            services.AddScoped<IPessoaRepository<Pessoa>, PessoaRepository>();
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
                        
            return services;
        }
    }
}
