using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    public class FormaCompraController : BaseController<FormaCompra, FormaCompraDTO>
    {
        public FormaCompraController(FormaCompraService formaCompraService) 
            : base(formaCompraService) { }

        protected override int GetIdFromDto(FormaCompraDTO dto)
        {
            return dto.CodFC;
        }
    }
}
