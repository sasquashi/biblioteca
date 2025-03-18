using Biblioteca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IHistoricoAcaoRepository : IRepositoryBase<HistoricoAcao>
    {
        Task<List<HistoricoAcao>> GetByTabelaAsync(string tabela);
    }
}
