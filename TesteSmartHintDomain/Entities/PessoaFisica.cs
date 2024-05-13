using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PessoaFisica : Pessoa
    {
        public PessoaFisica()
        {
        }

        protected PessoaFisica(int id, string nome, string email, string telefone, DateTime dtCadastro, bool bloqueado, string CPF) : base(id, nome, email, telefone, dtCadastro, bloqueado)
        {
            this.CPF = CPF;
        }

        protected string CPF {  get; set; }

    }
}
