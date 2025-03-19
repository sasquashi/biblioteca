using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Api.Controllers
{
    public class AutorController : BaseController<Autor, AutorDTO>
    {
        public AutorController(AutorService autorService) 
            : base(autorService) { }

        protected override int GetIdFromDto(AutorDTO dto)
        {
            return dto.CodAu;
        }
    }
}