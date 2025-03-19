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
    public class FormaPagamentoService : BaseService<FormaPagamento, FormaPagamentoDTO>
    {
        public FormaPagamentoService(IFormaPagamentoRepository formaPagamentoRepository) 
            : base(formaPagamentoRepository) { }

        protected override FormaPagamentoDTO MapToDto(FormaPagamento formaPagamento)
        {
            return formaPagamento == null ? null : new FormaPagamentoDTO
            {
                CodFP = formaPagamento.CodFP,
                Descricao = formaPagamento.Descricao
            };
        }

        protected override FormaPagamento MapToEntity(FormaPagamentoDTO dto)
        {
            return new FormaPagamento { Descricao = dto.Descricao };
        }

        protected override void UpdateEntity(FormaPagamento formaPagamento, FormaPagamentoDTO dto)
        {
            formaPagamento.Descricao = dto.Descricao;
        }

        protected override int GetIdFromDto(FormaPagamentoDTO dto)
        {
            return dto.CodFP;
        }
    }
}