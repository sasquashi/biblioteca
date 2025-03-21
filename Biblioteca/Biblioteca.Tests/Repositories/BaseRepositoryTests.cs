using Biblioteca.Domain.Entities;
using Biblioteca.Infra.Data.Context;
using Biblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using System.Linq;

namespace Biblioteca.Tests.Repositories
{
    public class BaseRepositoryTests
    {
        private readonly Mock<BibliotecaDbContext> _contextMock;
        private readonly Mock<DbSet<TestEntity>> _dbSetMock;
        private readonly BaseRepository<TestEntity> _repository;

        public BaseRepositoryTests()
        {
            _contextMock = new Mock<BibliotecaDbContext>();
            _dbSetMock = new Mock<DbSet<TestEntity>>();
            _contextMock.Setup(c => c.Set<TestEntity>()).Returns(_dbSetMock.Object);
            _repository = new BaseRepository<TestEntity>(_contextMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEntity()
        {
            var entity = new TestEntity { Id = 1 };
            _dbSetMock.Setup(m => m.FindAsync(1)).ReturnsAsync(entity);
            var result = await _repository.GetByIdAsync(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task AddAsync_SavesEntity()
        {
            var entity = new TestEntity { Id = 1 };
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);
            await _repository.AddAsync(entity);
            _dbSetMock.Verify(m => m.Add(entity), Times.Once());
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task UpdateAsync_SavesEntity()
        {
            var entity = new TestEntity { Id = 1 };
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);
            await _repository.UpdateAsync(entity);
            _dbSetMock.Verify(m => m.Update(entity), Times.Once());
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_RemovesEntity()
        {
            var entity = new TestEntity { Id = 1 };
            _dbSetMock.Setup(m => m.FindAsync(1)).ReturnsAsync(entity);
            _contextMock.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);
            await _repository.DeleteAsync(1);
            _dbSetMock.Verify(m => m.Remove(entity), Times.Once());
            _contextMock.Verify(c => c.SaveChangesAsync(default), Times.Once());
        }

        [Fact]
        public async Task DeleteAsync_DoesNothing_WhenEntityNotFound()
        {
            _dbSetMock.Setup(m => m.FindAsync(1)).ReturnsAsync((TestEntity)null);
            await _repository.DeleteAsync(1);
            _dbSetMock.Verify(m => m.Remove(It.IsAny<TestEntity>()), Times.Never());
        }
    }

    public class TestEntity { public int Id { get; set; } }
}