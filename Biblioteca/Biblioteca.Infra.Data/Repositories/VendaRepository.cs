using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;

namespace Biblioteca.Infra.Data.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public VendaRepository(BibliotecaDbContext context) 
            : base(context) { }
    }
}