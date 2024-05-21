using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TektonLabs.HxArq.Api.Controllers;
using TektonLabs.HxArq.Application.Commands;
using TektonLabs.HxArq.Application.Dtos;
using TektonLabs.HxArq.Application.Queries;

namespace TektonLabs.HxArq.Test
{
    public class ProductTest
    {
        [Fact]
        public async Task CrearProducto_DevuelveResultado()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var validatorMock = new Mock<IValidator<CreateProductCommand>>();
            validatorMock.Setup(v => v.ValidateAsync(It.IsAny<CreateProductCommand>(), default)).ReturnsAsync(new ValidationResult());

            var controller = new ProductsController(mediatorMock.Object, validatorMock.Object, null);
            var command = new CreateProductCommand
            {
                Name = "Test Product",
                Status = 1,
                Stock = 10,
                Description = "Test Description",
                Price = 39.9m
            };

            mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), default)).ReturnsAsync(1);

            // Act
            var result = await controller.CreateProduct(command);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetProductById", actionResult.ActionName);
            Assert.Equal(1, actionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task ObtenerProductoPorID_RetornaObjeto()
        {
            // Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new ProductsController(mediatorMock.Object, null, null);

            mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), default)).ReturnsAsync(new ProductDTO { ProductId = 1, Name = "Test Product" });

            // Act
            var result = await controller.GetProductById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var product = Assert.IsType<ProductDTO>(okResult.Value);
            Assert.Equal(1, product.ProductId);
            Assert.Equal("Test Product", product.Name);
        }
    }
}