using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteSmartHint.WebApp.Models
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

        protected PessoaFisica(int id, string nome, string email, string telefone, DateTime dtCadastro,
            bool bloqueado, string inscricaoEstadual, string CPF, string Genero, DateTime dtNascimento) : base(id, nome, email, telefone, dtCadastro, bloqueado, inscricaoEstadual)
        {
            this.CPF = CPF;
            this.Genero = Genero;
            this.dtNascimento = dtNascimento;
        }

        public string CPF;
        public string Genero;
        public DateTime dtNascimento;
    }
}