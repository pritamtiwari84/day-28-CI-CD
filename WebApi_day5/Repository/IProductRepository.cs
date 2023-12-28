using WebApi_day5.Models;

namespace WebApi_day5.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        List<Product> GetProductsByName(string productName);
        void AddProduct(Product product);
        void UpdateProduct(int productId, Product updatedProduct);
        void DeleteProduct(int productId);
    }
}