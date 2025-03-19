using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class FormaPagamento
    {
        [Key]
        public int CodFP { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos
        public List<Venda> Vendas { get; set; } = new List<Venda>();
        #endregion
    }
}
