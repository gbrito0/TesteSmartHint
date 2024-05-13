using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;

namespace TesteSmartHint.Application.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IMapper _mapper;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository, IMapper mapper)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _mapper = mapper;
        }

        public Task Add(PessoaFisica pessoa)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PessoaFisica>> GetAll()
        {
            try
            {
                var lstPessoaFisica = await _pessoaFisicaRepository.GetAll();
                return lstPessoaFisica;

            }catch (Exception ex) { throw ex; }
        }

        public Task<PessoaFisica> GetPessoaFisicaAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
