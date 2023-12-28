using WebApi_day5.Models;


namespace WebApi_day5.Repository

{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            // Initialize with some sample data
            products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", ProductBrand = "HP", ProductQuantity = 10, ProductPrice = 1000.0m },
            new Product { ProductId = 2, ProductName = "Phone", ProductBrand = "Samsung", ProductQuantity = 20, ProductPrice = 500.0m }
        };
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetProductsByName(string productName)
        {
            return products.Where(p => p.ProductName.Contains(productName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void AddProduct(Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
        }

        public void UpdateProduct(int productId, Product updatedProduct)
        {
            var existingProduct = products.FirstOrDefault(p => p.ProductId == productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = updatedProduct.ProductName;
                existingProduct.ProductBrand = updatedProduct.ProductBrand;
                existingProduct.ProductQuantity = updatedProduct.ProductQuantity;
                existingProduct.ProductPrice = updatedProduct.ProductPrice;
            }
        }

        public void DeleteProduct(int productId)
        {
            var productToRemove = products.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
            }
        }
    }
}