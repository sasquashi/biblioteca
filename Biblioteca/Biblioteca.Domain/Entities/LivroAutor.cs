using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class LivroAutor
    {
        [Key]
        public int Livro_CodL { get; set; }
        public int Autor_CodAu { get; set; }

        #region Relacionamentos
        public Livro Livro { get; set; }
        public Autor Autor { get; set; }
        #endregion
    }
}
