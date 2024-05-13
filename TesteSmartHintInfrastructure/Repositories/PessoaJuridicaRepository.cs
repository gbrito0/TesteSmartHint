using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TesteSmartHint.Domain.Entities;
using TesteSmartHint.Domain.Interfaces;
using TesteSmartHint.Infrastructure.Context;

namespace TesteSmartHint.Infrastructure.Repositories
{
    public class PessoaJuridicaRepository : IPessoaJuridicaRepository
    {
        private readonly DapperContext _context;

        public PessoaJuridicaRepository(DapperContext pessoaJuridicaContext)
        {
            _context = pessoaJuridicaContext;
        }

        public async Task<PessoaJuridica> Add(PessoaJuridica pessoaJuridica)
        {
            var sql =
                @"INSERT INTO PessoaJuridica
                        (ID, CNPJ)
                VALUES 
                        (@ID, @CNPJ)";

            var parameters = new DynamicParameters();
            parameters.Add("ID", pessoaJuridica.Id, DbType.Int64);
            parameters.Add("CNPJ", pessoaJuridica.CNPJ, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var retorno = await connection.QueryAsync(sql, parameters);
                    return pessoaJuridica;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<PessoaJuridica> GetById(int id)
        {
            var query = string.Format(@"  
                            SELECT p.*, pj.CNPJ 
                            FROM PessoaJuridica pj
                            INNER JOIN pessoa p on pj.ID = p.ID
                            WHERE pj.ID = {0}", id);
            using (var connection = _context.CreateConnection())
            {
                var pj  = await connection.QueryFirstOrDefaultAsync<PessoaJuridica>(query);
                return pj;
            }
        }

        public async Task<IEnumerable<PessoaJuridica>> GetAll()
        {
            var query = @"  SELECT p.*, pj.CNPJ 
                            FROM PessoaJuridica pj
                            INNER JOIN pessoa p on pj.ID = p.ID";
            using (var connection = _context.CreateConnection())
            {
                var pj = await connection.QueryAsync<PessoaJuridica>(query);
                return pj;
            }
        }


        public Task<int> Update(PessoaJuridica entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> validaCNPJ(string CNPJ)
        {
            throw new NotImplementedException();
        }

        public Task<bool> validaEmail(string CPF)
        {
            throw new NotImplementedException();
        }
    }
}
