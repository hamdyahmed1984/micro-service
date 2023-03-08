using AutoMapper;
using ProductService.Dtos;
using ProductService.Models;

namespace ProductService.Mapping;
public class ProductMapping: Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}