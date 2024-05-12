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
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaFisicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PessoaFisica> GetById(int id)
        {
            try
            {
                return await _context.PessoaFisica.FindAsync(id);
            }catch (Exception ex) { throw; }
            
        }
        public async Task<IEnumerable<PessoaFisica>> GetAll()
        {
            try
            {
                var lstPF = await _context.PessoaFisica.ToListAsync();
                return lstPF;
            }catch(Exception ex) { throw; } 
        }
        public async Task<PessoaFisica> Add(PessoaFisica entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
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
