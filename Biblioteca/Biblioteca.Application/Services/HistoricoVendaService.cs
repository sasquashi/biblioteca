using Biblioteca.Application.DTOs;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services
{
    public class HistoricoVendaService
    {
        private readonly IHistoricoVendaRepository _historicoVendaRepository;

        public HistoricoVendaService()
        {
                    
        }

        public HistoricoVendaService(IHistoricoVendaRepository historicoVendaRepository)
        {
            _historicoVendaRepository = historicoVendaRepository;
        }

        public async Task<HistoricoVendaDTO> GetByIdAsync(int id)
        {
            var historico = await _historicoVendaRepository.GetByIdAsync(id);
            return MapToDto(historico);
        }

        public async Task<List<HistoricoVendaDTO>> GetAllAsync()
        {
            var historicos = await _historicoVendaRepository.GetAllAsync();
            return historicos.Select(MapToDto).ToList();
        }

        public async Task<List<HistoricoVendaDTO>> GetByVendaIdAsync(int vendaId)
        {
            var historicos = await _historicoVendaRepository.GetByVendaIdAsync(vendaId);
            return historicos.Select(MapToDto).ToList();
        }

        public async Task AddAsync(HistoricoVenda historico)
        {
            await _historicoVendaRepository.AddAsync(historico);
        }

        private HistoricoVendaDTO MapToDto(HistoricoVenda historico)
        {
            if (historico == null) return null;
            return new HistoricoVendaDTO
            {
                CodHV = historico.CodHV,
                CodV = historico.CodV,
                CodFC = historico.CodFC,
                CodL = historico.CodL,
                ValorLivro = historico.ValorLivro,
                TeveDesconto = historico.TeveDesconto,
                ValorFinal = historico.ValorFinal,
                DataVenda = historico.DataVenda,
                CodFP = historico.CodFP,
                DataModificacao = historico.DataModificacao
            };
        }
    }
}