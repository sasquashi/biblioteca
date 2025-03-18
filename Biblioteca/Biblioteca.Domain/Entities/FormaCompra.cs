using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class FormaCompra
    {
        public int CodFC { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos
        public List<Venda> Vendas { get; set; } = new List<Venda>();
        #endregion
    }
}
