using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infra.Data.Repositories
{
    public class HistoricoAcaoRepository : BaseRepository<HistoricoAcao>, IHistoricoAcaoRepository
    {
        private readonly BibliotecaDbContext _context;

        public HistoricoAcaoRepository(BibliotecaDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<HistoricoAcao>> GetByTabelaAsync(string tabela)
        {
            return await _context.HistoricoAcoes
                .Where(ha => ha.TabelaAfetada == tabela)
                .ToListAsync();
        }
    }
}
