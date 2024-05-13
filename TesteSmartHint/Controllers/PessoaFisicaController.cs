using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<IEnumerable<PessoaFisica>>> GetAll()
        {
            var lstPessoaFisica = await _pessoaFisicaService.GetAll();
            return Ok(lstPessoaFisica);
        }

        [HttpGet("{id}", Name = "GetPessoaFisicaById")]
        public async Task<ActionResult<PessoaFisica>> GetPessoaFisicaById(int id)
        {
            try
            {
                var pessoa = await _pessoaFisicaService.GetPessoaFisicaAsync(id);
                if (pessoa == null)
                    return NotFound();
                else
                    return Ok(pessoa);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaFisica pessoaFisica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pessoaFisicaService.Add(pessoaFisica);
                return Ok(pessoaFisica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
