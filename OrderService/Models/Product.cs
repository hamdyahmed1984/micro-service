using System.ComponentModel.DataAnnotations;

namespace OrderService.Models;
public class Product
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public int ExternalId { get; set; }
    [Required]
    public string Name { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}