using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;

namespace Biblioteca.Infra.Data.Repositories
{
    public class FormaPagamentoRepository : BaseRepository<FormaPagamento>, IFormaPagamentoRepository
    {
        public FormaPagamentoRepository(BibliotecaDbContext context) 
            : base(context) { }
    }
}