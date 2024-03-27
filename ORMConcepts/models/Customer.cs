namespace ORMConcepts.models;

using System.ComponentModel.DataAnnotations;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
        
    [Required]
    public required string Name { get; set; }
        
    public string Email { get; set; } = null!;
}