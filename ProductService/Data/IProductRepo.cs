using ProductService.Models;

namespace ProductService.Data;
public interface IProductRepo
{
    bool SaveChanges();
    IEnumerable<Product> GetProducts();
    Product GetProduct(int id);
    void CreateProduct(Product prod);
}