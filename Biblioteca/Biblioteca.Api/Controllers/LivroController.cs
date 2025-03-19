using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    public class LivroController : BaseController<Livro, LivroDTO>
    {
        public LivroController(LivroService livroService) 
            : base(livroService) { }

        protected override int GetIdFromDto(LivroDTO dto)
        {
            return dto.CodL;
        }
    }
}