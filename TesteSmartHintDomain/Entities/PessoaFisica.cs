using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica() { }

        protected PessoaFisica(int id, string nome, string email, int telefone, DateTime dtCadastro,
            bool bloqueado, int? inscricaoEstadual, string CPF, string Genero, DateTime dtNascimento) : base(id, nome, email, telefone, dtCadastro, bloqueado, inscricaoEstadual)
        {
            this.CPF = CPF;
            this.Genero = Genero;
            this.dtNascimento = dtNascimento;
        }

        public string CPF { get; set; }
        public string Genero { get; set; }
        public DateTime dtNascimento { get; set; }

    }
}
