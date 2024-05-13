using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.Interfaces;
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
        public async Task<ActionResult<IEnumerable<PessoaJuridica>>> GetAll()
        {
            var lstPessoaJuridica = await _pessoaJuridicaService.GetAll();
            return Ok(lstPessoaJuridica);
        }

        [HttpGet("{id}", Name = "GetPessoaJuridicaById")]
        public async Task<ActionResult<PessoaJuridica>> GetPessoaJuridicaById(int id)
        {
            try
            {
                var pessoa = await _pessoaJuridicaService.GetPessoaJuridicaAsync(id);
                if (pessoa == null)
                    return NotFound();
                else
                    return Ok(pessoa);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PessoaJuridica pessoaJuridica)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _pessoaJuridicaService.Add(pessoaJuridica);
                return Ok(pessoaJuridica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
