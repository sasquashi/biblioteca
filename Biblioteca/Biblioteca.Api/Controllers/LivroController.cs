using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Biblioteca.Api.Controllers
{
    public class LivroController : BaseController<Livro, LivroDTO>
    {
        public LivroController(LivroService livroService)
            : base(livroService) { }
        //esse dataAnnotation de codeanalysis é importante pois o código é trivial.
        //Sendo assim em caso de uso do SONAR seria excluido da cobertura.
        //Pois a maior lógica já se encontra testada na BaseController
        [ExcludeFromCodeCoverage]
        protected override int GetIdFromDto(LivroDTO dto)
        {
            return dto.CodL;
        }
    }
}