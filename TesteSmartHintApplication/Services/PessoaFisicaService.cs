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
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IMapper _mapper;

        public PessoaFisicaService(IPessoaFisicaRepository pessoaFisicaRepository, IMapper mapper)
        {
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _mapper = mapper;
        }

        public async Task<PessoaFisicaDTO> Add(PessoaFisicaDTO pessoaFisicaDTO)
        {
            var pessoaFisica = _mapper.Map<PessoaFisica>(pessoaFisicaDTO);
            return _mapper.Map<PessoaFisicaDTO>(await _pessoaFisicaRepository.Add(pessoaFisica));
        }

        public async Task<IEnumerable<PessoaFisicaDTO>> GetAll()
        {
            var lstPessoaFisica = await _pessoaFisicaRepository.GetAll();
            return _mapper.Map<IEnumerable<PessoaFisicaDTO>>(lstPessoaFisica);
        }

        public async Task<PessoaFisicaDTO> GetPessoaFisicaById(int id)
        {
            var pessoaFisica = await _pessoaFisicaRepository.GetById(id);
            return _mapper.Map<PessoaFisicaDTO>(pessoaFisica);
        }

        public async Task<PessoaFisicaDTO> Update(PessoaFisicaDTO pessoaFisicaDTO)
        {
            var pessoaFisica = _mapper.Map<PessoaFisica>(pessoaFisicaDTO);
            return _mapper.Map<PessoaFisicaDTO>(await _pessoaFisicaRepository.Update(pessoaFisica));
        }

        public async Task Delete(int id)
        {
            await _pessoaFisicaRepository.Delete(id);
        }

        public async Task<bool> ValidaCPF(string CPF)
        {            
            return await _pessoaFisicaRepository.ValidaCampo(CPF);
        }
    }
}
