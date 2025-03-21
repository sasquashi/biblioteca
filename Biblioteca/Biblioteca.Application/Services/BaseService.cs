using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public abstract class BaseService<T, TDto> where T
        : class where TDto
        : class
    {
        protected readonly IRepositoryBase<T> _repository;
        protected readonly HistoricoAcaoService _historicoAcaoService;
        protected readonly HistoricoVendaService _historicoVendaService;

        public BaseService()
        {
            //necessidade de criar um construtor vazio para poder resolver os erros do projeto de testes. Sem ele todos os testes quebram
            //pois o moq precisa para poder mockar as coisas.
        }

        protected BaseService(
                    IRepositoryBase<T> repository,
                    HistoricoAcaoService historicoAcaoService,
                    HistoricoVendaService historicoVendaService)
        {
            _repository = repository;
            _historicoAcaoService = historicoAcaoService;
            _historicoVendaService = historicoVendaService;
        }

        public virtual async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return MapToDto(entity);
        }

        public virtual async Task<List<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(MapToDto).ToList();
        }

        public virtual async Task AddAsync(TDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);

            var historicoAcao = new HistoricoAcao
            {
                TabelaAfetada = typeof(T).Name,
                TipoAcao = "INSERT",
                DescricaoAcao = $"Ação INSERT na tabela {typeof(T).Name}.",
                DataAcao = DateTime.Now,
                UsuarioAcao = Environment.UserName 
            };
            await _historicoAcaoService.AddAsync(historicoAcao);

            if (typeof(T) == typeof(Venda))
            {
                var venda = entity as Venda;
                var historicoVenda = new HistoricoVenda
                {
                    CodV = venda.CodV,
                    CodFC = venda.CodFC,
                    CodL = venda.CodL,
                    ValorLivro = venda.ValorLivro,
                    TeveDesconto = venda.TeveDesconto,
                    ValorFinal = venda.ValorFinal,
                    DataVenda = venda.DataVenda,
                    CodFP = venda.CodFP,
                    DataModificacao = DateTime.Now,
                    UsuarioModificacao = Environment.UserName
                };
                await _historicoVendaService.AddAsync(historicoVenda);
            }
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = await _repository.GetByIdAsync(GetIdFromDto(dto));
            if (entity == null) throw new Exception($"{typeof(T).Name} não encontrado");
            UpdateEntity(entity, dto);
            await _repository.UpdateAsync(entity);

            var historicoAcao = new HistoricoAcao
            {
                TabelaAfetada = typeof(T).Name,
                TipoAcao = "UPDATE",
                DescricaoAcao = $"Ação UPDATE na tabela {typeof(T).Name}.",
                DataAcao = DateTime.Now,
                UsuarioAcao = Environment.UserName
            };
            await _historicoAcaoService.AddAsync(historicoAcao);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);

            var historicoAcao = new HistoricoAcao
            {
                TabelaAfetada = typeof(T).Name,
                TipoAcao = "DELETE",
                DescricaoAcao = $"Ação DELETE na tabela {typeof(T).Name}.",
                DataAcao = DateTime.Now,
                UsuarioAcao = Environment.UserName
            };
            await _historicoAcaoService.AddAsync(historicoAcao);
        }

        protected abstract TDto MapToDto(T entity);
        protected abstract T MapToEntity(TDto dto);
        protected abstract void UpdateEntity(T entity, TDto dto);
        protected abstract int GetIdFromDto(TDto dto);
    }
}
