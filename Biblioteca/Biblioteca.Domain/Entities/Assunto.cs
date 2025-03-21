﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Entities
{
    public class Assunto
    {
        [Key]
        public int CodAS { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos
        public List<LivroAssunto> LivroAssuntos { get; set; } = new List<LivroAssunto>();
        #endregion
    }
}
