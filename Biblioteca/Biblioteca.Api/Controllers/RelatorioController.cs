using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Services;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _relatorioService;

        public RelatorioController(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("livros-por-autor")]
        public async Task<IActionResult> GetRelatorioLivrosPorAutor()
        {
            var pdfBytes = await _relatorioService.GenerateRelatorioLivrosPorAutorAsync();
            return File(pdfBytes, "application/pdf", "RelatorioLivrosPorAutor.pdf");
        }
    }
}