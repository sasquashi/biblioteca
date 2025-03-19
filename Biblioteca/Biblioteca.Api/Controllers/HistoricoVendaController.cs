using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoVendaController : ControllerBase
    {
        private readonly HistoricoVendaService _historicoVendaService;

        public HistoricoVendaController(HistoricoVendaService historicoVendaService)
        {
            _historicoVendaService = historicoVendaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var historico = await _historicoVendaService.GetByIdAsync(id);
            if (historico == null) return NotFound();
            return Ok(historico);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historicos = await _historicoVendaService.GetAllAsync();
            return Ok(historicos);
        }

        [HttpGet("venda/{vendaId}")]
        public async Task<IActionResult> GetByVendaId(int vendaId)
        {
            var historicos = await _historicoVendaService.GetByVendaIdAsync(vendaId);
            return Ok(historicos);
        }
    }
}