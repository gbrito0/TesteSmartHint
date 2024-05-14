using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Mapping
{
    public class DomainToDTOMappingProfile: Profile
    {
        public DomainToDTOMappingProfile() { 
            CreateMap<Pessoa, PessoaDTO>()
                .ForMember(dest => dest.CodigoPessoa, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<PessoaFisica, PessoaFisicaDTO>()
                .ForMember(dest => dest.CodigoPessoa, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<PessoaJuridica, PessoaJuridicaDTO>()
                .ForMember(dest => dest.CodigoEmpresa, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RazaoSocial, opt => opt.MapFrom(src => src.Nome))
                .ReverseMap();
        }
    }
}
