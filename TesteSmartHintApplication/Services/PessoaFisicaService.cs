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

        public async Task<PessoaFisica> Add(PessoaFisica pessoaFisica)
        {
            try
            {
                return await _pessoaFisicaRepository.Add(pessoaFisica);
            }
            catch (Exception ex) { }
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PessoaFisica>> GetAll()
        {
            try
            {
                var lstPessoaFisica = await _pessoaFisicaRepository.GetAll();
                return lstPessoaFisica;

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<PessoaFisica> GetPessoaFisicaById(int id)
        {
            return await _pessoaFisicaRepository.GetById(id);
        }

        public async Task<PessoaFisica> Update(PessoaFisica pessoa)
        {
            return await _pessoaFisicaRepository.Update(pessoa);
        }

        public async Task Delete(int id)
        {            
            await _pessoaFisicaRepository.Delete(id);
        }
    }
}
