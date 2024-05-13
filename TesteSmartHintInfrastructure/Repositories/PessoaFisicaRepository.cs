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
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly DapperContext _context;

        public PessoaFisicaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<PessoaFisica> GetById(int id)
        {
            throw new NotImplementedException();

        }
        public async Task<IEnumerable<PessoaFisica>> GetAll()
        {
            throw new NotImplementedException();
        }
        public async Task<PessoaFisica> Add(PessoaFisica entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(PessoaFisica entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
