using System;
using System.ComponentModel.DataAnnotations;

namespace OrderService.Models;
public class Order
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime Created { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
}