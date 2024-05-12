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
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly ApplicationDbContext _pessoaJuridicaContext;

        public PessoaJuridicaRepository(ApplicationDbContext pessoaJuridicaContext)
        {
            _pessoaJuridicaContext = pessoaJuridicaContext;
        }

        public async Task<PessoaJuridica> Add(PessoaJuridica entity)
        {
            _pessoaJuridicaContext.Add(entity);
            await _pessoaJuridicaContext.SaveChangesAsync();
            return entity;
        }

        public async Task<PessoaJuridica> GetById(int id)
        {
            try
            {
                return await _pessoaJuridicaContext.PessoaJuridica.FindAsync(id);
            }catch (Exception) { throw; }                        
        }

        public async Task<IEnumerable<PessoaJuridica>> GetAll()
        {
            try
            {
                var lstPJ = await _pessoaJuridicaContext.PessoaJuridica.ToListAsync();
                return lstPJ;
            }
            catch (Exception) { throw; }
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
