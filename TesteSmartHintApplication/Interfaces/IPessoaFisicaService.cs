using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaFisicaService
    {
        Task<IEnumerable<PessoaFisica>> GetAll();
        Task<PessoaFisica> GetPessoaFisicaById(int id);
        Task<PessoaFisica> Add(PessoaFisica pessoa);        
        Task<PessoaFisica> Update(PessoaFisica pessoa);
        Task Delete(int id);
    }
}
