using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infrastructure.Context;

namespace TesteSmartHint.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository<Pessoa>
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> GetById(int id)
        {
            try
            {
                return await _context.Pessoa.FindAsync(id);
            }
            catch (Exception ex) { throw; }
        }
        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            try
            {
                var lstPessoa = await _context.Pessoa.ToListAsync();
                return lstPessoa;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<Pessoa> Add(Pessoa entity)
        {
            _context.Pessoa.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<int> Update(Pessoa entity)
        {
            throw new NotImplementedException();
        }
    }
}
