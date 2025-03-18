using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class HistoricoVenda
    {
        public int CodHV { get; set; }
        public int CodV { get; set; }
        public int CodFC { get; set; }
        public int CodL { get; set; }
        public decimal ValorLivro { get; set; }
        public bool TeveDesconto { get; set; }
        public decimal ValorFinal { get; set; }
        public DateTime DataVenda { get; set; }
        public int CodFP { get; set; }
        public DateTime DataModificacao { get; set; }
        public string UsuarioModificacao { get; set; }

        #region Relacionamentos
        public Venda Venda { get; set; }
        #endregion
    }
}
