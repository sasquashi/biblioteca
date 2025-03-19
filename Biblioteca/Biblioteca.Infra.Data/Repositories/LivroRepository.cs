using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(BibliotecaDbContext context) 
            : base(context) { }

        public override async Task<Livro> GetByIdAsync(int id)
        {
            return await _context.Livros
                .Include(l => l.LivroAutores)
                .Include(l => l.LivroAssuntos)
                .FirstOrDefaultAsync(l => l.CodL == id);
        }

        public override async Task<List<Livro>> GetAllAsync()
        {
            return await _context.Livros
                .Include(l => l.LivroAutores)
                .Include(l => l.LivroAssuntos)
                .ToListAsync();
        }
    }
}