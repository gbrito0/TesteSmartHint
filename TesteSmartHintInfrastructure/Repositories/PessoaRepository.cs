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
    public class PessoaRepository : IPessoaRepository<Pessoa>
    {
        private readonly DapperContext _context;

        public PessoaRepository(DapperContext context)
        {
            _context = context;
        }
        

        public async Task<Pessoa> GetById(int id)
        {
            var query = string.Format(@"
                                        SELECT Id, Nome, Email, Telefone, dtCadastro, Bloqueado
                                        FROM Pessoa
                                        WHERE Pessoa.ID = {0}",id);
            using(var connection = _context.CreateConnection())
            {
                var pessoa = await connection.QueryFirstOrDefaultAsync<Pessoa>(query);
                return pessoa;
            }
        }
        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            var query = @"SELECT Id, Nome, Email, Telefone, dtCadastro, Bloqueado FROM Pessoa";
            using (var connection = _context.CreateConnection())
            {
                var pessoa = await connection.QueryAsync<Pessoa>(query);
                return pessoa;
            }
        }
        public async Task<Pessoa> Add(Pessoa pessoa)
        {
            
            var sql =
                @"INSERT INTO Pessoa
                        (Nome, Email, Telefone, dtCadastro, Bloqueado)
                VALUES 
                        (@Nome, @Email, @Telefone, @dtCadastro, @Bloqueado)";

            var parameters = new DynamicParameters();
            parameters.Add("Nome", pessoa.Nome, DbType.String);
            parameters.Add("Email", pessoa.Email, DbType.String);
            parameters.Add("Telefone", pessoa.Telefone, DbType.String);
            parameters.Add("dtCadastro", DateTime.Now, DbType.DateTime);
            parameters.Add("Bloqueado", pessoa.Bloqueado == true ? 1 : 0, DbType.Boolean);
            parameters.Add("InscricaoEstadual", pessoa.InscricaoEstadual, DbType.Int64);


            using (var connection = _context.CreateConnection())
            {
                var retorno = await connection.QueryAsync(sql, parameters);
                return pessoa;
            }
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
