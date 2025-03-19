using Biblioteca.Application.DTOs;
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    public class FormaPagamentoController : BaseController<FormaPagamento, FormaPagamentoDTO>
    {
        public FormaPagamentoController(FormaPagamentoService formaPagamentoService) : base(formaPagamentoService) { }

        protected override int GetIdFromDto(FormaPagamentoDTO dto)
        {
            return dto.CodFP;
        }
    }
}
