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
                var pj = await connection.QueryFirstOrDefaultAsync<PessoaJuridica>(query);
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


        public async Task<PessoaJuridica> Update(PessoaJuridica pessoaJuridica)
        {
            var query = string.Format(@"  
                            UPDATE PessoaJuridica SET
                            CNPJ = '{1}'
                            WHERE ID = {0}",
                            pessoaJuridica.Id, pessoaJuridica.CNPJ);
            using (var connection = _context.CreateConnection())
            {
                var pf = await connection.QueryFirstOrDefaultAsync<PessoaJuridica>(query);
                return pessoaJuridica;
            }
        }

        public async Task Delete(int id)
        {
            var query = string.Format(@"DELETE FROM PessoaJuridica WHERE ID = {0}", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query);
            }
        }

        //Valida CNPJ
        public async Task<bool> ValidaCampo(string CNPJ)
        {
            var query = string.Format(@"SELECT EXISTS(SELECT ID FROM PessoaJuridica WHERE CNPJ = '{0}') as CNPJCadastrado", CNPJ);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstAsync<bool>(query);
            }
        }
    }
}
