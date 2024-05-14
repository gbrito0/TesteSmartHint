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
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IMapper _mapper;

        public PessoaJuridicaService(IPessoaJuridicaRepository pessoaJuridicaRepository, IMapper mapper)
        {
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaJuridica>> GetAll()
        {
            var lstPessoaJurdica = await _pessoaJuridicaRepository.GetAll();
            return lstPessoaJurdica;
        }

        public async Task<PessoaJuridica> GetPessoaJuridicaById(int id)
        {
            return await _pessoaJuridicaRepository.GetById(id);
        }

        public async Task<PessoaJuridica> Add(PessoaJuridica pessoaJuridica)
        {
            return await _pessoaJuridicaRepository.Add(pessoaJuridica);
        }

        public async Task<PessoaJuridica> Update(PessoaJuridica pessoaJuridica)
        {
            return await _pessoaJuridicaRepository.Update(pessoaJuridica);
        }

        public async Task Delete(int id)
        {
            await _pessoaJuridicaRepository.Delete(id);
        }
    }
}
