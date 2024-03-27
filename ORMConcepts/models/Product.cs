namespace ORMConcepts.models;

using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId { get; set; }
        
    [Required]
    public required string Name { get; set; }
        
    public decimal Price { get; set; }
        
    public int Quantity { get; set; }
}