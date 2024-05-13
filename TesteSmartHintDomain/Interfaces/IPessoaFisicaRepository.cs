using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Domain.Interfaces
{
    public interface IPessoaFisicaRepository : IPessoaRepository<PessoaFisica>
    {
        Task<bool> validaCPF(string CPF);
    }
}
