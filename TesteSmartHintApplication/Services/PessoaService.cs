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
    public class PessoaService : IPessoaService
    {

        private IPessoaRepository<Pessoa> _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository<Pessoa> pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaDTO>> GetAll()
        {
            var lstPessoa = await _pessoaRepository.GetAll();
            return _mapper.Map<IEnumerable<PessoaDTO>>(lstPessoa);
        }

        public async Task<PessoaDTO> GetPessoaById(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);
            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public async Task<PessoaDTO> Add(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            return _mapper.Map<PessoaDTO>(await _pessoaRepository.Add(pessoa));
        }

        public async Task<PessoaDTO> Update(PessoaDTO pessoaDTO)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            return _mapper.Map<PessoaDTO>(await _pessoaRepository.Update(pessoa));
        }

        public async Task Delete(int id)
        {
            await _pessoaRepository.Delete(id);
        }

        public async Task<bool> ValidaEmail(string Email)
        {
            return await _pessoaRepository.ValidaCampo(Email);
        }

        public Task<bool> ValidaInscricaoEstadual(string inscricaoEstadual)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PessoaDTO>> GetByFiltro(Dictionary<string, string> filtros)
        {            
            filtros = filtros.ToDictionary(obj => obj.Key.ToLower(), obj => obj.Value);
            var retorno = await _pessoaRepository.GetByFiltro(filtros);            
            return _mapper.Map<IEnumerable<PessoaDTO>>(retorno); 
        }


    }
}
