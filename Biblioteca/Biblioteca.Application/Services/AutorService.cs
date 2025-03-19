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
    public class AutorService : BaseService<Autor, AutorDTO>
    {
        public AutorService(IAutorRepository autorRepository) 
            : base(autorRepository) { }

        protected override AutorDTO MapToDto(Autor autor)
        {
            return autor == null ? null : new AutorDTO { CodAu = autor.CodAU, Nome = autor.Nome };
        }

        protected override Autor MapToEntity(AutorDTO dto)
        {
            return new Autor { Nome = dto.Nome };
        }

        protected override void UpdateEntity(Autor autor, AutorDTO dto)
        {
            autor.Nome = dto.Nome;
        }

        protected override int GetIdFromDto(AutorDTO dto)
        {
            return dto.CodAu;
        }
    }
}
