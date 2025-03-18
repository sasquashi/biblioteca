using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Autor
    {
        public int CodAU { get; set; }
        public string Nome { get; set; }

        #region Relacionamentos
        public List<LivroAutor> LivroAutores { get; set; } = new List<LivroAutor>();
        #endregion
    }
}
