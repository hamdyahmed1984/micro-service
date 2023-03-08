using ProductService.Models;

namespace ProductService.Data;

public class ProductRepo : IProductRepo
{
    private readonly AppDbContext _context;

    public ProductRepo(AppDbContext context) => _context = context;
    public void CreateProduct(Product prod)
    {
          if(prod == null) throw new ArgumentNullException(nameof(prod));
          _context.Products.Add(prod);
    }
    public Product GetProduct(int id) => _context.Products.SingleOrDefault(p => p.Id == id);

    public IEnumerable<Product> GetProducts() => _context.Products.ToList();

    public bool SaveChanges() => _context.SaveChanges() >= 0;
}