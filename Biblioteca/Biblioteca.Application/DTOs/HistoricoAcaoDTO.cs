﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.DTOs
{
    public class HistoricoAcaoDTO
    {
        public int CodHA { get; set; }
        public string TabelaAfetada { get; set; }
        public string TipoAcao { get; set; }
        public string DescricaoAcao { get; set; }
        public DateTime DataAcao { get; set; }
        public string UsuarioAcao { get; set; }
    }
}
