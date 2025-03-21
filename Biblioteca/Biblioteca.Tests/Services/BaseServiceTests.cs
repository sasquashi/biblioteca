
using Biblioteca.Application.Services;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Moq;
using Xunit;

namespace Biblioteca.Tests.Services
{
    public class BaseServiceTests
    {
        private readonly Mock<IRepositoryBase<TestEntity>> _repositoryMock;
        private readonly Mock<HistoricoAcaoService> _historicoAcaoMock;
        private readonly Mock<HistoricoVendaService> _historicoVendaMock;
        private readonly TestService _service;

        public BaseServiceTests()
        {
            _repositoryMock = new Mock<IRepositoryBase<TestEntity>>();
            _historicoAcaoMock = new Mock<HistoricoAcaoService>();
            _historicoVendaMock = new Mock<HistoricoVendaService>();
            _service = new TestService(_repositoryMock.Object, _historicoAcaoMock.Object, _historicoVendaMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_RetornaUmUnicoDTO()
        {
            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(new TestEntity { Id = 1 });
            var result = await _service.GetByIdAsync(1);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_RetornaListaComVariosDTOs()
        {
            var entities = new List<TestEntity> { new TestEntity { Id = 1 } };
            _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
            var result = await _service.GetAllAsync();
            Assert.Single(result);
            Assert.Equal(1, result[0].Id);
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_QuandoAEntidadeNaoEEncontrada()
        {
            var dto = new TestDto { Id = 1 };
            _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((TestEntity)null);
            await Assert.ThrowsAsync<Exception>(() => _service.UpdateAsync(dto));
        }

        //continuar demais testes
    }

    public class TestEntity { public int Id { get; set; } }
    public class TestDto { public int Id { get; set; } }
    public class TestService : BaseService<TestEntity, TestDto>
    {
        public TestService(IRepositoryBase<TestEntity> repository, HistoricoAcaoService historicoAcaoService, HistoricoVendaService historicoVendaService)
            : base(repository, historicoAcaoService, historicoVendaService) { }
        protected override TestDto MapToDto(TestEntity entity) => new TestDto { Id = entity.Id };
        protected override TestEntity MapToEntity(TestDto dto) => new TestEntity { Id = dto.Id };
        protected override void UpdateEntity(TestEntity entity, TestDto dto) => entity.Id = dto.Id;
        protected override int GetIdFromDto(TestDto dto) => dto.Id;
    }
}