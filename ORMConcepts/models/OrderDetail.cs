namespace ORMConcepts.models;

using System.ComponentModel.DataAnnotations;

public class OrderDetail
{
    [Key]
    public int OrderDetailId { get; set; }
        
    // Foreign key for Order
    public int OrderId { get; set; }
        
    // Navigation property
    public required Order Order { get; set; }
        
    // Foreign key for Product
    public int ProductId { get; set; }
        
    // Navigation property
    public required Product Product { get; set; }
        
    public int Quantity { get; set; }
}