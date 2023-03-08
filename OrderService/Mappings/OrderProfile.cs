
using AutoMapper;
using OrderService.Models;
using OrderService.Dtos;

namespace OrderService.Mappings;
public class OrderProfile: Profile
{
    public OrderProfile()
    {
        CreateMap<Product, ProductReadDto>();
        CreateMap<Order, OrderReadDto>();
        CreateMap<OrderCreateDto, Order>();
    }
}