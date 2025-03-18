using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class LivroDTO
    {
        public int CodL { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public int Edicao { get; set; }
        public string AnoPublicacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<int> AutorIds { get; set; }
        public List<int> AssuntoIds { get; set; }
    }
}
