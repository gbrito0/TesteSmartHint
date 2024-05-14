using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaJuridicaService
    {
        Task<IEnumerable<PessoaJuridicaDTO>> GetAll();
        Task<PessoaJuridicaDTO> GetPessoaJuridicaById(int id);
        Task<PessoaJuridicaDTO> Add(PessoaJuridicaDTO pessoaJuridica);
        Task<PessoaJuridicaDTO> Update(PessoaJuridicaDTO pessoaJuridica);
        Task Delete(int id);
        Task<bool> ValidaCNPJ(string CNPJ);
    }
}
