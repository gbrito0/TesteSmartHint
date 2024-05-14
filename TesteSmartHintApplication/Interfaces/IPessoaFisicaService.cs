using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.Application.Interfaces
{
    public interface IPessoaFisicaService
    {
        Task<IEnumerable<PessoaFisicaDTO>> GetAll();
        Task<PessoaFisicaDTO> GetPessoaFisicaById(int id);
        Task<PessoaFisicaDTO> Add(PessoaFisicaDTO pessoa);        
        Task<PessoaFisicaDTO> Update(PessoaFisicaDTO pessoa);
        Task Delete(int id);
        Task<bool> ValidaCPF(string CPF);
    }
}
