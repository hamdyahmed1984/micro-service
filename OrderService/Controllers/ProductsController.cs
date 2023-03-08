using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;
using OrderService.Dtos;

namespace OrderService.Controllers;

[Route("api/orders/[controller]")]
[ApiController]
public class ProductsController: ControllerBase
{
    private readonly IOrderRepo _repo;
    private readonly IMapper _mapper;

    public ProductsController(IOrderRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper= mapper;
    }

    [HttpPost]
    public ActionResult TestInboundConnections()
    {
        Console.WriteLine(" --> Inbound POST to the Orders Service");
        return Ok(" --> inbound test form the products controller.");
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
    {
        Console.WriteLine(" --> Getting all products");
        var products = _repo.GetProducts();
        return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
    }
}