using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Biblioteca.Api.Controllers
{
    public class AssuntoController : BaseController<Assunto, AssuntoDTO>
    {
        public AssuntoController(AssuntoService assuntoService) 
            : base(assuntoService) { }

        //esse dataAnnotation de codeanalysis é importante pois o código é trivial.
        //Sendo assim em caso de uso do SONAR seria excluido da cobertura.
        //Pois a maior lógica já se encontra testada na BaseController
        [ExcludeFromCodeCoverage]
        protected override int GetIdFromDto(AssuntoDTO dto)
        {
            return dto.CodAs;
        }
    }
}