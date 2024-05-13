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
    public class PessoaService : IPessoaService
    {

        private IPessoaRepository<Pessoa> _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository<Pessoa> pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            var lstPessoa = await _pessoaRepository.GetAll();
            return lstPessoa;
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);
            return pessoa;
        }

        public async Task<Pessoa> Add(Pessoa pessoa)
        {            
            return await _pessoaRepository.Add(pessoa); 
        }
    }
}
