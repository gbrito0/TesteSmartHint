using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static TesteSmartHint.Domain.Entities.Filtro;

namespace TesteSmartHint.Domain.Entities
{
    public class Pessoa
    {
        protected Pessoa(int id, string nome, string email, string telefone, DateTime dtCadastro, bool bloqueado)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            this.dtCadastro = dtCadastro;
            Bloqueado = bloqueado;      
        }

        protected int Id { get; set; }
        protected string Nome { get; set; }
        protected string Email { get; set;}
        protected string Telefone { get; set;}
        protected DateTime dtCadastro { get; set; }
        protected bool Bloqueado {  get; set;}
    }
}
