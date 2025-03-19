using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;

namespace Biblioteca.Infra.Data.Repositories
{
    public class AssuntoRepository : BaseRepository<Assunto>, IAssuntoRepository
    {
        public AssuntoRepository(BibliotecaDbContext context) : base(context) { }
    }
}