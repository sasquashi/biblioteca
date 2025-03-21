using System.Data;
using System.Threading.Tasks;

namespace Biblioteca.Domain.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<DataTable> GetLivrosPorAutorAsync();
    }
}
