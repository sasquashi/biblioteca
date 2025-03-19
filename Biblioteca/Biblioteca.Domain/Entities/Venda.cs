using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Venda
    {
        [Key]
        public int CodV { get; set; }
        public int CodFC { get; set; }
        public int CodL { get; set; }
        public decimal ValorLivro { get; set; }
        public bool TeveDesconto { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataVenda { get; set; }
        public int CodFP { get; set; }

        #region Relacionamentos
        public FormaCompra FormaCompra { get; set; }
        public Livro Livro { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public List<HistoricoVenda> HistoricoVendas { get; set; } = new List<HistoricoVenda>();
        #endregion
    }
}
