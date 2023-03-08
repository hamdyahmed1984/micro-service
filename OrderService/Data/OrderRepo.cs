using OrderService.Models;

namespace OrderService.Data;
public class OrderRepo : IOrderRepo
{
    private readonly AppDbContext _context;

    public OrderRepo(AppDbContext context)
    {
        _context = context;
    }   
    public void AddProduct(int orderId, Product prod)
    {
        if(prod == null)
        {
            throw new ArgumentNullException(nameof(prod));
        }
        prod.OrderId = orderId;
        _context.Products.Add(prod);
    }

    public void CreateOrder(Order order)
    {
        if(order ==null)
        {
            throw new ArgumentNullException(nameof(order));
        }
        _context.Orders.Add(order);
    }

    public void CreateProduct(Product prod)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetOrderProducts(int orderId) => _context.Products.Where(p => p.OrderId == orderId).OrderBy(p=>p.Order.Created);

    public Product GetProductInOrder(int orderId, int prodId) => _context.Orders.SingleOrDefault(p=>p.Id == orderId)?.Products.SingleOrDefault(p=>p.Id==prodId);

    public IEnumerable<Product> GetProducts() => _context.Products;

    public bool ProductExists(int prodId) => _context.Products.Any(p =>p.Id == prodId);

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}