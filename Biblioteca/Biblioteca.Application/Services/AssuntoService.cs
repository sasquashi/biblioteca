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
    public class AssuntoService : BaseService<Assunto, AssuntoDTO>
    {
        public AssuntoService(IAssuntoRepository assuntoRepository) : base(assuntoRepository) { }

        protected override AssuntoDTO MapToDto(Assunto assunto)
        {
            return assunto == null ? null : new AssuntoDTO { CodAs = assunto.CodAS, Descricao = assunto.Descricao };
        }

        protected override Assunto MapToEntity(AssuntoDTO dto)
        {
            return new Assunto { Descricao = dto.Descricao };
        }

        protected override void UpdateEntity(Assunto assunto, AssuntoDTO dto)
        {
            assunto.Descricao = dto.Descricao;
        }

        protected override int GetIdFromDto(AssuntoDTO dto)
        {
            return dto.CodAs;
        }
    }
}
