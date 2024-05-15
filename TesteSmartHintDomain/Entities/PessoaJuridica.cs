using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica() { }


        public PessoaJuridica(int id, string nome, string email, long telefone, DateTime dtCadastro, bool bloqueado, long? inscricaoEstadual, string CNPJ)
            : base(id, nome, email, telefone, dtCadastro, bloqueado, inscricaoEstadual)
        {
            this.CNPJ = CNPJ;
        }

        public string CNPJ { get; set; }
    }
}
