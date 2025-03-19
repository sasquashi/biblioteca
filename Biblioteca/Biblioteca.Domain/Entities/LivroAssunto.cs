using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class LivroAssunto
    {
        [Key]
        public int Livro_CodL { get; set; }
        public int Assunto_CodAs { get; set; }

        #region Relacionamentos
        public Livro Livro { get; set; }
        public Assunto Assunto { get; set; }
        #endregion
    }
}
