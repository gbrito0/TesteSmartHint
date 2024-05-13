using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSmartHint.Application.Interfaces;
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
    }
}
