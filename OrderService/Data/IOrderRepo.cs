using OrderService.Models;

namespace OrderService.Data;
public interface IOrderRepo
{
    bool SaveChanges();
    IEnumerable<Product> GetProducts();
    void CreateProduct(Product prod);
    bool ProductExists(int prodId);

    IEnumerable<Product> GetOrderProducts(int orderId);
    Product GetProductInOrder(int orderId, int prodId);
    void CreateOrder(Order order);
    void AddProduct(int orderId, Product prod);
}