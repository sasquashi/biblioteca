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
    public class VendaService : BaseService<Venda, VendaDTO>
    {
        public VendaService(IVendaRepository vendaRepository) 
            : base(vendaRepository) { }

        protected override VendaDTO MapToDto(Venda venda)
        {
            if (venda == null) return null;
            return new VendaDTO
            {
                CodV = venda.CodV,
                CodFC = venda.CodFC,
                CodL = venda.CodL,
                ValorLivro = venda.ValorLivro,
                TeveDesconto = venda.TeveDesconto,
                ValorFinal = venda.ValorFinal,
                DataVenda = venda.DataVenda,
                CodFP = venda.CodFP
            };
        }

        protected override Venda MapToEntity(VendaDTO dto)
        {
            return new Venda
            {
                CodFC = dto.CodFC,
                CodL = dto.CodL,
                ValorLivro = dto.ValorLivro,
                TeveDesconto = dto.TeveDesconto,
                ValorFinal = dto.ValorFinal,
                DataVenda = DateTime.Now,
                CodFP = dto.CodFP
            };
        }

        protected override void UpdateEntity(Venda venda, VendaDTO dto)
        {
            venda.CodFC = dto.CodFC;
            venda.CodL = dto.CodL;
            venda.ValorLivro = dto.ValorLivro;
            venda.TeveDesconto = dto.TeveDesconto;
            venda.ValorFinal = dto.ValorFinal;
        }

        protected override int GetIdFromDto(VendaDTO dto)
        {
            return dto.CodV;
        }
    }
}
