namespace SalesTransactionAnalysis;

class Transaction
{
    public int TransactionId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}
    
class ProductSales
{
    public int ProductId { get; set; }
    public double TotalSales { get; set; }
}