using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TesteSmartHint.WebApp.DTO;
using TesteSmartHint.WebApp.Models;

namespace TesteSmartHint.WebApp.Mapeamentos
{
    public sealed class AutoMapperConfig
    {
        public AutoMapperConfig() { }

        public static Mapper InicializarProfiles()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PessoaDTO, Pessoa>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CodigoPessoa))
                .ReverseMap();                                
            });

            return new Mapper(config);
        }
    }
}