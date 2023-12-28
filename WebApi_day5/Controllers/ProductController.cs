using Microsoft.AspNetCore.Mvc;
using WebApi_day5.Models;
using WebApi_day5.Repository;

namespace Day_3assingment.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepoy)
        {
            productRepository = productRepoy;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = productRepository.GetProductById(productId);

                if (product == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("byname/{productName}")]
        public IActionResult GetProductsByName(string productName)
        {
            try
            {
                var products = productRepository.GetProductsByName(productName);
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("Add Product")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Invalid product data.");
                }

                productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProductById), new { productId = product.ProductId }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] Product updatedProduct)
        {
            try
            {
                var existingProduct = productRepository.GetProductById(productId);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                productRepository.UpdateProduct(productId, updatedProduct);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var existingProduct = productRepository.GetProductById(productId);

                if (existingProduct == null)
                {
                    return NotFound($"Product with ID {productId} not found.");
                }

                productRepository.DeleteProduct(productId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}