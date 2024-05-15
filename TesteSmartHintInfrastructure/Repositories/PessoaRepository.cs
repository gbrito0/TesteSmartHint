using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                                        WHERE Pessoa.ID = {0}", id);
            using (var connection = _context.CreateConnection())
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
                        (@Nome, @Email, @Telefone, @dtCadastro, @Bloqueado);
                SELECT LAST_INSERT_ID()";

            var parameters = new DynamicParameters();
            parameters.Add("Nome", pessoa.Nome, DbType.String);
            parameters.Add("Email", pessoa.Email, DbType.String);
            parameters.Add("Telefone", pessoa.Telefone, DbType.String);
            parameters.Add("dtCadastro", DateTime.Now, DbType.DateTime);
            parameters.Add("Bloqueado", pessoa.Bloqueado == true ? 1 : 0, DbType.Boolean);
            parameters.Add("InscricaoEstadual", pessoa.InscricaoEstadual, DbType.Int64);

            using (var connection = _context.CreateConnection())
            {
                var retorno = await connection.QueryAsync<int>(sql, parameters);
                pessoa.Id = retorno.Single();
                return pessoa;
            }
        }

        public async Task Delete(int id)
        {
            var query = string.Format(@"DELETE FROM Pessoa WHERE ID = {0}", id);
            using (var connection = _context.CreateConnection())
            {
                var x = await connection.QueryAsync(query);
            }
        }
        public async Task<Pessoa> Update(Pessoa pessoa)
        {
            var query = string.Format(@"  
                            UPDATE Pessoa SET
                            Nome = '{1}', Email = '{2}', Telefone = '{3}', Bloqueado = {4}
                            WHERE ID = {0}",
                            pessoa.Id, pessoa.Nome, pessoa.Email, pessoa.Telefone, pessoa.Bloqueado);
            using (var connection = _context.CreateConnection())
            {
                var pf = await connection.QueryFirstOrDefaultAsync<PessoaFisica>(query);
                return pessoa;
            }
        }

        //Valida Email
        public async Task<bool> ValidaCampo(string email)
        {
            var query = string.Format(@"SELECT EXISTS(SELECT ID FROM Pessoa WHERE Email = '{0}') as EmailCadastrado", email);
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstAsync<bool>(query);
            }
        }

        public async Task<IEnumerable<Pessoa>> GetByFiltro(IDictionary<string, string> filtros)
        {
            string query = "SELECT Id, Nome, Email, Telefone, dtCadastro, Bloqueado FROM Pessoa WHERE 1 = 1";
            var parametros = new DynamicParameters();            
            query = MontaQueryFiltros(query, filtros, ref parametros);

            using (var connection = _context.CreateConnection())
            {
                try
                {
                    var pessoa = await connection.QueryAsync<Pessoa>(query, parametros);
                    return pessoa;
                }
                catch(Exception ex) { throw ex; }
                
                
            }
        }

        private String MontaQueryFiltros(String query, IDictionary<string, string> filtro, ref DynamicParameters parametros) {            
            
            StringBuilder sql = new StringBuilder();            
            sql.Append(query);
            string valor;

            if (filtro.TryGetValue("nome", out valor))
            {
                sql.Append(" AND Nome like @Nome");
                parametros.Add("Nome", $"%{valor}%");
            }
            if (filtro.TryGetValue("email", out valor))
            {
                sql.Append(" AND Email like @Email");
                parametros.Add("Email", $"%{valor}%");
            }
            if (filtro.TryGetValue("telefone", out valor))
            {
                sql.Append(" AND Telefone = @Telefone");
                parametros.Add("Telefone", Regex.Replace(valor, @"[^\d]",""));                    
            }
            if (filtro.TryGetValue("bloqueado", out valor))
            {
                sql.Append(" AND Bloqueado = @Bloqueado");
                parametros.Add("Bloqueado",valor);
            }

            return sql.ToString();

            //DATAS
        }
    }
}
