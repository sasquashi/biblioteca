using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Api.Controllers
{
    public class AssuntoController : BaseController<Assunto, AssuntoDTO>
    {
        public AssuntoController(AssuntoService assuntoService) 
            : base(assuntoService) { }

        protected override int GetIdFromDto(AssuntoDTO dto)
        {
            return dto.CodAs;
        }
    }
}