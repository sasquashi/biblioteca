using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Api.Controllers
{
    public class VendaController : BaseController<Venda, VendaDTO>
    {
        public VendaController(VendaService vendaService) 
            : base(vendaService) { }

        protected override int GetIdFromDto(VendaDTO dto)
        {
            return dto.CodV;
        }
    }
}