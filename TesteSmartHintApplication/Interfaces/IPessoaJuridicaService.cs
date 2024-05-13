using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaJuridicaService
    {
        Task<IEnumerable<PessoaJuridica>> GetAll();
        Task<PessoaJuridica> GetPessoaJuridicaById(int id);
        Task<PessoaJuridica> Add(PessoaJuridica pessoaJuridica);
        Task<PessoaJuridica> Update(PessoaJuridica pessoaJuridica);
        Task Delete(int id);
    }
}
