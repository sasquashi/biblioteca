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
    public class HistoricoVendaRepository : BaseRepository<HistoricoVenda>, IHistoricoVendaRepository
    {
        private readonly BibliotecaDbContext _context;

        public HistoricoVendaRepository(BibliotecaDbContext context)
            : base(context) 
        {
            _context = context;
        }

        public async Task<List<HistoricoVenda>> GetByVendaIdAsync(int vendaId)
        {
            return await _context.HistoricoVendas
                .Where(hv => hv.CodV == vendaId)
                .ToListAsync();
        }
    }
}
