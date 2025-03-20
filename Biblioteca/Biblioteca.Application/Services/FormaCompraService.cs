using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public class FormaCompraService : BaseService<FormaCompra, FormaCompraDTO>
    {
        public FormaCompraService(
            IFormaCompraRepository formaCompraRepository,
            HistoricoAcaoService historicoAcaoService,
            HistoricoVendaService historicoVendaService)
            : base(formaCompraRepository, historicoAcaoService, historicoVendaService) { }

        protected override FormaCompraDTO MapToDto(FormaCompra formaCompra)
        {
            return formaCompra == null ? null : new FormaCompraDTO
            {
                CodFC = formaCompra.CodFC,
                Descricao = formaCompra.Descricao
            };
        }

        protected override FormaCompra MapToEntity(FormaCompraDTO dto)
        {
            return new FormaCompra { Descricao = dto.Descricao };
        }

        protected override void UpdateEntity(FormaCompra formaCompra, FormaCompraDTO dto)
        {
            formaCompra.Descricao = dto.Descricao;
        }

        protected override int GetIdFromDto(FormaCompraDTO dto)
        {
            return dto.CodFC;
        }
    }
}