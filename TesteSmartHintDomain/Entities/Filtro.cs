using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSmartHint.Domain.Entities
{
    public sealed class Filtro
    {
        public enum eFiltros
        {
            Nome = 1,
            Email = 2,
            Telefone = 3,
            dtCadastro = 4,
            Bloqueado = 5
        }
    }
}
