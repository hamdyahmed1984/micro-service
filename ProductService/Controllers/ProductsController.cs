using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using ProductService.Dtos;
using ProductService.Models;
using ProductService.SyncDataServices.Http;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IProductRepo _repo;
    private readonly IMapper _mapper;
    private readonly IOrderDataClient _orderDataClient;

    public ProductsController(IProductRepo repo, IMapper mapper, IOrderDataClient orderDataClient)
    {
        _repo = repo;
        _mapper = mapper;
        _orderDataClient = orderDataClient;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetProducts()
    {
        var prods = _repo.GetProducts();
        return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(prods));
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<ProductReadDto> GetProduct(int id)
    {
        var prod = _repo.GetProduct(id);
        return prod == null ? NotFound() : Ok(_mapper.Map<ProductReadDto>(prod));
    }

    [HttpPost]
    public async Task<ActionResult<ProductReadDto>> CreateProduct(ProductCreateDto prod)
    {
        var prodModel = _mapper.Map<Product>(prod);
        _repo.CreateProduct(prodModel);
        _repo.SaveChanges();

        var prodReadDto = _mapper.Map<ProductReadDto>(prodModel);

        try
        {
            await _orderDataClient.SendProductToOrder(prodReadDto);
        }
        catch(Exception ex)
        {
            Console.WriteLine($" --> couldn't send synchronously: {ex.Message}");
        }
        return CreatedAtRoute("GetProductById", new {Id = prodReadDto.Id}, prodReadDto);
    }
}