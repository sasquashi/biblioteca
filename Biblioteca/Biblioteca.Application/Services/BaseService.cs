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

        protected BaseService(IRepositoryBase<T> repository)
        {
            _repository = repository;
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
        }

        public virtual async Task UpdateAsync(TDto dto)
        {
            var entity = await _repository.GetByIdAsync(GetIdFromDto(dto));
            if (entity == null) throw new Exception($"{typeof(T).Name} não encontrado");
            UpdateEntity(entity, dto);
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        protected abstract TDto MapToDto(T entity);
        protected abstract T MapToEntity(TDto dto);
        protected abstract void UpdateEntity(T entity, TDto dto);
        protected abstract int GetIdFromDto(TDto dto);
    }
}
