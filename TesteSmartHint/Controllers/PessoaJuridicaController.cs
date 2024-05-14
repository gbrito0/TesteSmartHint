using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.DTOs;
using TesteSmartHint.Application.Interfaces;
using TesteSmartHint.Application.Services;
using TesteSmartHint.Domain.Entities;

namespace TesteSmartHint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;
        public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaService)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaJuridicaDTO>>> GetAll()
        {
            var lstPessoaJuridica = await _pessoaJuridicaService.GetAll();
            return Ok(lstPessoaJuridica);
        }

        [HttpGet("{CodigoEmpresa}", Name = "GetPessoaJuridicaById")]
        public async Task<ActionResult<PessoaJuridicaDTO>> GetPessoaJuridicaById(int id)
        {
            var pessoa = await _pessoaJuridicaService.GetPessoaJuridicaById(id);
            if (pessoa == null)
                return NotFound();
            else
                return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaJuridicaDTO pessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _pessoaJuridicaService.Add(pessoaJuridica);
            return Ok(pessoaJuridica);

        }

        [HttpPut("{CodigoEmpresa}")]
        public async Task<ActionResult<PessoaJuridicaDTO>> Put(int id, [FromBody] PessoaJuridicaDTO pessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (id != pessoaJuridica.CodigoEmpresa)
            {
                ModelState.AddModelError("ErrorMessage", "Id inválido");
                return BadRequest(ModelState);
            }

            await _pessoaJuridicaService.Update(pessoaJuridica);

            return Ok(pessoaJuridica);
        }

        [HttpDelete("{CodigoEmpresa}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _pessoaJuridicaService.Delete(id);
            return Ok();
        }

        [HttpGet("ValidaCNPJ")]
        public async Task<ActionResult<bool>> ValidaCNPJ(string CNPJ)
        {
            var CNPJEncontrado = await _pessoaJuridicaService.ValidaCNPJ(CNPJ);
            return (Ok(!CNPJEncontrado));
        }
    }
}
