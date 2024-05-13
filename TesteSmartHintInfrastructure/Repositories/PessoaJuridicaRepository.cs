using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infrastructure.Context;

namespace TesteSmartHint.Infrastructure.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly DapperContext _pessoaJuridicaContext;

        public PessoaJuridicaRepository(DapperContext pessoaJuridicaContext)
        {
            _pessoaJuridicaContext = pessoaJuridicaContext;
        }

        public async Task<PessoaJuridica> Add(PessoaJuridica entity)
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaJuridica> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PessoaJuridica>> GetAll()
        {
            throw new NotImplementedException();
        }


        public Task<int> Update(PessoaJuridica entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
