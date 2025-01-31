using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Domains;
using WebApplication1.Models;

namespace TestProject1
{
    public class ProductControllerUnitTest
    {
        private readonly Mock<IProductDomain> _mockDomain;
        private readonly Mock<ILogger<ProductController>> _mockLogger;
        private readonly ProductController _controller;

        public ProductControllerUnitTest()
        {
            _mockDomain = new Mock<IProductDomain>();
            _mockLogger = new Mock<ILogger<ProductController>>();
            _controller = new ProductController(_mockDomain.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            
            var mockProducts = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    ProductCode = "CodeTest01",
                    Title = "Product test 1",
                    Description = "Description 1",
                    Price = 10.99m,
                    Stock = 100
                },
                new Product
                {
                    ID = 2,
                    ProductCode = "CodeTest02",
                    Title = "Product test 2",
                    Description = "Description 2",
                    Price = 20.99m,
                    Stock = 200
                }
            };

            _mockDomain
                .Setup(service => service.GetProducts(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(mockProducts);

            var result = await _controller.GetProducts();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(2, returnedProducts.Count);
        }

        [Fact]
        public async Task GetProducts_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            _mockDomain
                .Setup(service => service.GetProducts(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception("Simulated error"));

            var result = await _controller.GetProducts();

            var objectResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Internal server error: Unable to fetch products.", objectResult.Value);
        }

        [Fact]
        public async Task GetProducts_ReturnsPaginatedResults()
        {
            var mockProducts = new List<Product>
            {
                new Product { ID = 1, ProductCode = "ProductTest01", Title = "Product test 1", Price = 10.99m, Stock = 100 },
                new Product { ID = 2, ProductCode = "ProductTest02", Title = "Product test 2", Price = 20.99m, Stock = 200 },
                new Product { ID = 3, ProductCode = "ProductTest03", Title = "Product test 3", Price = 30.99m, Stock = 300 }
            };

            _mockDomain
                .Setup(service => service.GetProducts(1, 2))
                .ReturnsAsync(mockProducts.Take(2).ToList());

            var result = await _controller.GetProducts(page: 1, pageSize: 2);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(2, returnedProducts.Count);
            Assert.Equal("ProductTest01", returnedProducts[0].ProductCode);
            Assert.Equal("ProductTest02", returnedProducts[1].ProductCode);
        }

    }
}
