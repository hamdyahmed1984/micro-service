using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Dtos;

namespace OrderService.Controllers;

[ApiController]
[Route("api/orders/products/{productId}/pcontroller]")]
public class OrdersController: ControllerBase
{
    private readonly IOrderRepo _repo;
    private readonly IMapper _mapper;

    public OrdersController(IOrderRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    // [HttpGet]
    // public ActionResult<IEnumerable<ProductReadDto>> GetProductsForOrder(int orderId)
    // {
    //     Console.WriteLine($" --> Getting products for order: {orderId}");
    //     var prod = _repo.GetOrderProducts(orderId);
    //     return Ok(_mapper.Map<IEnumerable<IProduct)
    // }
}