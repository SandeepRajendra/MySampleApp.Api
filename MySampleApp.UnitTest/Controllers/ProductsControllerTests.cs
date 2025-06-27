using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MySampleApp.Api.Controllers;
using MySampleApp.Application.Commands;
using MySampleApp.Application.Queries;
using MySampleApp.Domain.Entities;

namespace MySampleApp.UnitTest.Controllers
{
    public class ProductsControllerTests
    {
        private readonly Mock<ISender> _senderMock;
        private readonly ProductsController _controller;

        // The constructor sets up our mocks and creates the controller.
        public ProductsControllerTests()
        {
            _senderMock = new Mock<ISender>();
            _controller = new ProductsController(_senderMock.Object);
        }

        // Test for adding a product. This verifies that AddProduct returns an OkObjectResult with the expected product.
        [Fact]
        public async Task AddProduct_ReturnsOkResult_WithProduct()
        {
            // Arrange: Set up a sample product and configure the mock to return this product
            var product = new ProductEntity 
            { 
                Id = 1, 
                Name = "Wireless Bluetooth Headphones", 
                Quantity = 25 
            };
            _senderMock.Setup(x => x.Send(It.IsAny<AddProductCommand>(), default))
                       .ReturnsAsync(product);

            // Act: Call the controller method
            var result = await _controller.AddProduct(product);

            // Assert: Verify that the result is an OkObjectResult containing our product.
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<ProductEntity>(okResult.Value);

            Assert.Equal(product.Id, returnedProduct.Id);
            Assert.Equal("Wireless Bluetooth Headphones", returnedProduct.Name);
            Assert.Equal(25, returnedProduct.Quantity);
        }

        // Test for retrieving all products.
        [Fact]
        public async Task GetAllProduct_ReturnsOkResult_WithProducts()
        {
            // Arrange: Set up a list of sample products and configure the mock query.
            var products = new List<ProductEntity>
            {
                new ProductEntity 
                { 
                    Id = 1, 
                    Name = "Wireless Bluetooth Headphones",
                    Quantity = 25
                },
                new ProductEntity 
                { 
                    Id = 3, 
                    Name = "Mens Casual Premium Slim Fit T-Shirts",
                    Quantity = 120
                }
            };
            _senderMock.Setup(x => x.Send(It.IsAny<GetAllProductsQuery>(), default))
                       .ReturnsAsync(products);

            // Act: Get all products via the controller.
            var result = await _controller.GetAllProduct();

            // Assert: Check for an Ok result and that the returned list matches.
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProducts = Assert.IsAssignableFrom<List<ProductEntity>>(okResult.Value);

            Assert.Equal(2, returnedProducts.Count);
            Assert.Contains(returnedProducts, p => p.Name == "Wireless Bluetooth Headphones");
            Assert.Contains(returnedProducts, p => p.Name == "Mens Casual Premium Slim Fit T-Shirts");
        }

        // Test for retrieving a product by ID when the product is not found.
        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductIsNull()
        {
            // Arrange: Configure the mock to return null for a product lookup.
            _senderMock.Setup(x => x.Send(It.IsAny<GetProductByIdQuery>(), default))
                       .ReturnsAsync((ProductEntity?)null);

            // Act: Call the method with an ID that does not exist.
            var result = await _controller.GetProductById(11);

            // Assert: The controller should return a NotFoundObjectResult.
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains("No product found", notFoundResult.Value?.ToString());
        }

        // Test for updating a product successfully.
        [Fact]
        public async Task UpdateProduct_ReturnsOkResult_WhenUpdateSuccessful()
        {
            // Arrange: Setup a product and configure the mock to return the updated product.
            var updatedProduct = new ProductEntity 
            { 
                Id = 3, 
                Name = "Mens Casual Premium Slim Fit T-Shirts - Updated",
                Quantity = 100
            };
            _senderMock.Setup(x => x.Send(It.IsAny<UpdateProductCommand>(), default))
                       .ReturnsAsync(updatedProduct);

            // Act: Update the product via the controller.
            var result = await _controller.UpdateProduct(3, updatedProduct);

            // Assert: Ensure the controller returns an OkObjectResult with the updated product.
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProduct = Assert.IsType<ProductEntity>(okResult.Value);

            Assert.Equal("Mens Casual Premium Slim Fit T-Shirts - Updated", returnedProduct.Name);
            Assert.Equal(100, returnedProduct.Quantity);
        }

        // Test for deleting a product that does not exist.
        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductIsNull()
        {
            // Arrange: Simulate failure in deleting the product (e.g., product not found)
            _senderMock.Setup(x => x.Send(It.IsAny<DeleteProductCommand>(), default))
                       .ReturnsAsync(false);

            // Act: Call the Delete action method.
            var result = await _controller.DeleteProduct(100);

            // Assert: The response should be a NotFoundObjectResult.
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Contains("No product found", notFoundResult.Value?.ToString());
        }
    }
}
