using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Livro
    {
        [Key]
        public int CodL { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }

        #region Relacionamentos
        public List<LivroAutor> LivroAutores { get; set; } = new List<LivroAutor>();
        public List<LivroAssunto> LivroAssuntos { get; set; } = new List<LivroAssunto>();
        public List<Venda> Vendas { get; set; } = new List<Venda>();
        #endregion
    }
}
