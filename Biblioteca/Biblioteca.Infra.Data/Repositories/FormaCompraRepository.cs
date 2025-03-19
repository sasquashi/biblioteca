using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;

namespace Biblioteca.Infra.Data.Repositories
{
    public class FormaCompraRepository : BaseRepository<FormaCompra>, IFormaCompraRepository
    {
        public FormaCompraRepository(BibliotecaDbContext context) 
            : base(context) { }
    }
}