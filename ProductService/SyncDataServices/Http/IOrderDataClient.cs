using ProductService.Dtos;

namespace ProductService.SyncDataServices.Http;
public interface IOrderDataClient
{
    Task SendProductToOrder(ProductReadDto prod);
}