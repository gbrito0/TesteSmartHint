﻿using System;
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
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly DapperContext _context;

        public PessoaFisicaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<PessoaFisica> GetById(int id)
        {
            var query = string.Format(@"  
                            SELECT p.*, pf.dtNascimento, pf.Genero, pf.CPF 
                            FROM PessoaFisica pf
                            INNER JOIN pessoa p on pf.ID = p.ID
                            WHERE pf.ID = {0}", id);
            using (var connection = _context.CreateConnection())
            {
                var pf = await connection.QueryFirstOrDefaultAsync<PessoaFisica>(query);
                return pf;
            }
        }
        public async Task<IEnumerable<PessoaFisica>> GetAll()
        {
            var query = @"  SELECT p.*, pf.dtNascimento, pf.Genero, pf.CPF 
                            FROM PessoaFisica pf
                            INNER JOIN pessoa p on pf.ID = p.ID";
            using (var connection = _context.CreateConnection())
            {
                var pf = await connection.QueryAsync<PessoaFisica>(query);
                return pf;
            }
        }
        public async Task<PessoaFisica> Add(PessoaFisica pessoaFisica)
        {
            var sql =
                @"INSERT INTO PessoaFisica
                        (ID, CPF, Genero, dtNascimento)
                VALUES 
                        (@ID, @CPF, @Genero, @dtNascimento)";

            var parameters = new DynamicParameters();
            parameters.Add("ID", pessoaFisica.Id, DbType.Int64);
            parameters.Add("CPF", pessoaFisica.CPF, DbType.String);
            parameters.Add("Genero", pessoaFisica.Genero, DbType.String);
            parameters.Add("dtNascimento", pessoaFisica.dtNascimento, DbType.Date);


            using (var connection = _context.CreateConnection())
            {

                var retorno = await connection.QueryAsync(sql, parameters);
                return pessoaFisica;

            }
        }

        public async Task<PessoaFisica> Update(PessoaFisica pessoaFisica)
        {
            var query = string.Format(@"  
                            UPDATE PessoaFisica SET
                            CPF = '{1}', Genero = '{2}', dtNascimento = '{3}'
                            WHERE ID = {0}",
                            pessoaFisica.Id, pessoaFisica.CPF, pessoaFisica.Genero, pessoaFisica.dtNascimento.ToString("yyyy-MM-dd"));
            using (var connection = _context.CreateConnection())
            {
                var pf = await connection.QueryFirstOrDefaultAsync<PessoaFisica>(query);
                return pessoaFisica;
            }
        }
        public async Task Delete(int id)
        {
            var query = string.Format(@"DELETE FROM PessoaFisica pf WHERE pf.ID = {0}", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync(query);
            }
        }

        public Task<bool> validaCPF(string CPF)
        {
            throw new NotImplementedException();
        }

        public Task<bool> validaEmail(string CPF)
        {
            throw new NotImplementedException();
        }
    }
}
