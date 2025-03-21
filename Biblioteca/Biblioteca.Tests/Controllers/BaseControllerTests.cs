using Biblioteca.Application.Services;
using Biblioteca.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Biblioteca.Tests.Controllers
{
    public class BaseControllerTests
    {
        private readonly Mock<BaseService<TestEntity, TestDto>> _serviceMock;
        private readonly TestController _controller;

        public BaseControllerTests()
        {
            _serviceMock = new Mock<BaseService<TestEntity, TestDto>>();
            _controller = new TestController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_QuandoAEntidadeExiste()
        {
            _serviceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(new TestDto { Id = 1 });
            var result = await _controller.Get(1);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var dto = Assert.IsType<TestDto>(okResult.Value);
            Assert.Equal(1, dto.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_QuandoEntidadeNaoExiste()
        {
            _serviceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync((TestDto)null);
            var result = await _controller.Get(1);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_ComEntidades()
        {
            var dtos = new List<TestDto> { new TestDto { Id = 1 } };
            _serviceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(dtos);
            var result = await _controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDtos = Assert.IsType<List<TestDto>>(okResult.Value);
            Assert.Single(returnedDtos);
        }

        [Fact]
        public async Task Post_ReturnsCreated_ComAsDTOS()
        {
            var dto = new TestDto { Id = 1 };
            _serviceMock.Setup(s => s.AddAsync(dto)).Returns(Task.CompletedTask);
            var result = await _controller.Post(dto);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdResult.ActionName);
            Assert.Equal(1, createdResult.RouteValues["id"]);
            Assert.Equal(dto, createdResult.Value);
        }

        [Fact]
        public async Task Put_ReturnsNoContent_QuandoOsIdsSaoCorrespondentes()
        {
            var dto = new TestDto { Id = 1 };
            _serviceMock.Setup(s => s.UpdateAsync(dto)).Returns(Task.CompletedTask);
            var result = await _controller.Put(1, dto);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_QuandoOsIdsNaoSaoCorrespondentes()
        {
            var dto = new TestDto { Id = 2 };
            var result = await _controller.Put(1, dto);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent()
        {
            _serviceMock.Setup(s => s.DeleteAsync(1)).Returns(Task.CompletedTask);
            var result = await _controller.Delete(1);
            Assert.IsType<NoContentResult>(result);
        }
    }


    public class TestEntity { public int Id { get; set; } }
    public class TestDto { public int Id { get; set; } }
    public class TestController : BaseController<TestEntity, TestDto>
    {
        public TestController(BaseService<TestEntity, TestDto> service) : base(service) { }
        protected override int GetIdFromDto(TestDto dto) => dto.Id;
    }
}