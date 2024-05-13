using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> GetAll();
        Task<Pessoa> GetPessoaAsync(int id);
        Task<Pessoa> Add(Pessoa pessoa);
    }
}
