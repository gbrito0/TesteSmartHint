using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica()
        {
        }


        protected PessoaJuridica(int id, string nome, string email, string telefone, DateTime dtCadastro, bool bloqueado, string CNPJ) 
            : base(id, nome, email, telefone, dtCadastro, bloqueado)
        {
            this.CNPJ = CNPJ;
        }

        protected string CNPJ { get; set; }
    }
}
