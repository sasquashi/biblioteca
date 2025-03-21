using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Biblioteca.Api.Controllers
{
    public class AutorController : BaseController<Autor, AutorDTO>
    {
        public AutorController(AutorService autorService) 
            : base(autorService) { }
        //esse dataAnnotation de codeanalysis é importante pois o código é trivial.
        //Sendo assim em caso de uso do SONAR seria excluido da cobertura.
        //Pois a maior lógica já se encontra testada na BaseController
        [ExcludeFromCodeCoverage]
        protected override int GetIdFromDto(AutorDTO dto)
        {
            return dto.CodAu;
        }
    }
}