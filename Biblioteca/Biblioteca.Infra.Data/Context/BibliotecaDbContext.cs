using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Context
{
    public class BibliotecaDbContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }
        public DbSet<LivroAssunto> LivroAssuntos { get; set; }
        public DbSet<FormaCompra> FormasCompra { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<HistoricoVenda> HistoricoVendas { get; set; }
        public DbSet<HistoricoAcao> HistoricoAcoes { get; set; }

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroAutor>()
                .HasKey(la => new { la.Livro_CodL, la.Autor_CodAu });
            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivroAutores)
                .HasForeignKey(la => la.Livro_CodL);
            modelBuilder.Entity<LivroAutor>()
                .HasOne(la => la.Autor)
                .WithMany(a => a.LivroAutores)
                .HasForeignKey(la => la.Autor_CodAu);

            modelBuilder.Entity<LivroAssunto>()
                .HasKey(la => new { la.Livro_CodL, la.Assunto_CodAs });
            modelBuilder.Entity<LivroAssunto>()
                .HasOne(la => la.Livro)
                .WithMany(l => l.LivroAssuntos)
                .HasForeignKey(la => la.Livro_CodL);
            modelBuilder.Entity<LivroAssunto>()
                .HasOne(la => la.Assunto)
                .WithMany(a => a.LivroAssuntos)
                .HasForeignKey(la => la.Assunto_CodAs);

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.FormaCompra)
                .WithMany(fc => fc.Vendas)
                .HasForeignKey(v => v.CodFC);
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Livro)
                .WithMany(l => l.Vendas)
                .HasForeignKey(v => v.CodL);
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.FormaPagamento)
                .WithMany(fp => fp.Vendas)
                .HasForeignKey(v => v.CodFP);

            modelBuilder.Entity<HistoricoVenda>()
                .HasOne(hv => hv.Venda)
                .WithMany(v => v.HistoricoVendas)
                .HasForeignKey(hv => hv.CodV);
        }
    }
}