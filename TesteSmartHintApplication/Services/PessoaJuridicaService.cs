using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TesteSmartHint.Application.DTOs;
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

        public async Task<IEnumerable<PessoaJuridicaDTO>> GetAll()
        {
            var lstPessoaJurdica = await _pessoaJuridicaRepository.GetAll();
            return _mapper.Map<IEnumerable<PessoaJuridicaDTO>>(lstPessoaJurdica);
        }

        public async Task<PessoaJuridicaDTO> GetPessoaJuridicaById(int id)
        {
            return _mapper.Map<PessoaJuridicaDTO>(await _pessoaJuridicaRepository.GetById(id));
        }

        public async Task<PessoaJuridicaDTO> Add(PessoaJuridicaDTO pessoaJuridicaDTO)
        {
            var pessoaJuridica = _mapper.Map<PessoaJuridica>(pessoaJuridicaDTO);
            return _mapper.Map<PessoaJuridicaDTO>(await _pessoaJuridicaRepository.Add(pessoaJuridica));
        }

        public async Task<PessoaJuridicaDTO> Update(PessoaJuridicaDTO pessoaJuridicaDTO)
        {
            var pessoaJuridica = _mapper.Map<PessoaJuridica>(pessoaJuridicaDTO);
            return _mapper.Map<PessoaJuridicaDTO>(await _pessoaJuridicaRepository.Update(pessoaJuridica));
        }

        public async Task Delete(int id)
        {
            await _pessoaJuridicaRepository.Delete(id);
        }

        public async Task<bool> ValidaCNPJ(string CNPJ)
        {
            return await _pessoaJuridicaRepository.ValidaCampo(CNPJ);
        }
    }
}
