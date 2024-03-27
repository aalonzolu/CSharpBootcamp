namespace ORMConcepts.models;

using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public int OrderId { get; set; }
        
    public DateTime OrderDate { get; set; }
        
    // Foreign key for Customer
    public int CustomerId { get; set; }
        
    // Navigation property
    public required Customer Customer { get; set; }
        
    // Collection navigation property for OrderDetails
    public required ICollection<OrderDetail> OrderDetails { get; set; }
}