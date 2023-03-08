using System.ComponentModel.DataAnnotations;

namespace ProductService.Dtos;
public class ProductCreateDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int Quantity { get; set; }
}