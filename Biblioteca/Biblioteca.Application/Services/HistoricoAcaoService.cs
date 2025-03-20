using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class HistoricoAcaoService
    {
        private readonly IHistoricoAcaoRepository _historicoAcaoRepository;

        public HistoricoAcaoService(IHistoricoAcaoRepository historicoAcaoRepository)
        {
            _historicoAcaoRepository = historicoAcaoRepository;
        }

        public async Task<HistoricoAcaoDTO> GetByIdAsync(int id)
        {
            var historico = await _historicoAcaoRepository.GetByIdAsync(id);
            return MapToDto(historico);
        }

        public async Task<List<HistoricoAcaoDTO>> GetAllAsync()
        {
            var historicos = await _historicoAcaoRepository.GetAllAsync();
            return historicos.Select(MapToDto).ToList();
        }

        public async Task<List<HistoricoAcaoDTO>> GetByTabelaAsync(string tabela)
        {
            var historicos = await _historicoAcaoRepository.GetByTabelaAsync(tabela);
            return historicos.Select(MapToDto).ToList();
        }

        public async Task AddAsync(HistoricoAcao historico)
        {
            await _historicoAcaoRepository.AddAsync(historico);
        }

        private HistoricoAcaoDTO MapToDto(HistoricoAcao historico)
        {
            if (historico == null) return null;
            return new HistoricoAcaoDTO
            {
                CodHA = historico.CodHA,
                TabelaAfetada = historico.TabelaAfetada,
                TipoAcao = historico.TipoAcao,
                DescricaoAcao = historico.DescricaoAcao,
                DataAcao = historico.DataAcao
            };
        }
    }
}