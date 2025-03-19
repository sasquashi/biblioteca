using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoAcaoController : ControllerBase
    {
        private readonly HistoricoAcaoService _historicoAcaoService;

        public HistoricoAcaoController(HistoricoAcaoService historicoAcaoService)
        {
            _historicoAcaoService = historicoAcaoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var historico = await _historicoAcaoService.GetByIdAsync(id);
            if (historico == null) return NotFound();
            return Ok(historico);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historicos = await _historicoAcaoService.GetAllAsync();
            return Ok(historicos);
        }

        [HttpGet("tabela/{tabela}")]
        public async Task<IActionResult> GetByTabela(string tabela)
        {
            var historicos = await _historicoAcaoService.GetByTabelaAsync(tabela);
            return Ok(historicos);
        }
    }
}