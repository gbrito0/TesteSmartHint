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
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;
        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaFisicaDTO>>> GetAll()
        {
            var lstPessoaFisica = await _pessoaFisicaService.GetAll();
            return Ok(lstPessoaFisica);
        }

        [HttpGet("{CodigoPessoa}", Name = "GetPessoaFisicaById")]
        public async Task<ActionResult<PessoaFisicaDTO>> GetPessoaFisicaById(int CodigoPessoa)
        {
            var pessoa = await _pessoaFisicaService.GetPessoaFisicaById(CodigoPessoa);
            if (pessoa == null)
                return NotFound();
            else
                return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaFisicaDTO pessoaFisica)
        {
            await _pessoaFisicaService.Add(pessoaFisica);
            return Ok(pessoaFisica);
        }

        [HttpPut("{CodigoPessoa}")]
        public async Task<ActionResult<PessoaFisicaDTO>> Put(int CodigoPessoa, [FromBody] PessoaFisicaDTO pessoaFisica)
        {
            if (CodigoPessoa != pessoaFisica.CodigoPessoa)
            {
                ModelState.AddModelError("ErrorMessage", "Id inválido");
                return BadRequest(ModelState);
            }

            var registro = await _pessoaFisicaService.GetPessoaFisicaById(CodigoPessoa);
            if (registro == null)
                return NotFound();

            await _pessoaFisicaService.Update(pessoaFisica);

            return Ok(pessoaFisica);
        }

        [HttpDelete("{CodigoPessoa}")]
        public async Task<ActionResult> Delete(int CodigoPessoa)
        {
            var registro = await _pessoaFisicaService.GetPessoaFisicaById(CodigoPessoa);
            if (registro == null)
                return NotFound();

            await _pessoaFisicaService.Delete(CodigoPessoa);
            return Ok();
        }
    }
}
