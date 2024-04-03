using ORMConcepts.models;


namespace ORMConcepts
{
    public class Service
    {
       
        public void SeedDatabase()
        {
            // TODO
        }
        
        public void TotalSalesPerProduct()
        {
            using var db = new OrmdbContext();
            var productSales = (db.OrderDetails ?? throw new InvalidOperationException())
                .ToList()
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalSales = g.Sum(od => (decimal?)od.Quantity * od.Product.Price)
                });

            foreach (var sale in productSales)
            {
                decimal totalSales = sale.TotalSales ?? 0;
                Console.WriteLine($"Product ID: {sale.ProductId}, Total Sales: {totalSales:C}");
            }
        }
        
        public void ProductsNeverOrdered()
        {
            using var db = new OrmdbContext();
            var productsNeverOrdered = (db.Products ?? throw new InvalidOperationException())
                .Where(p => db.OrderDetails != null && !db.OrderDetails.Any(od => od.ProductId == p.ProductId))
                .ToList();

            foreach (var product in productsNeverOrdered)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}");
            }
        }
        
        public void HighValueCustomers()
        {
            using var db = new OrmdbContext();
            decimal threshold = 1000;

            var highValueCustomers = (db.Orders ?? throw new InvalidOperationException())
                .GroupBy(o => o.CustomerId)
                .Where(g => g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.Product.Price)) > threshold)
                .Select(g => g.Key).ToList();

            foreach (var customerId in highValueCustomers)
            {
                Console.WriteLine($"Customer ID: {customerId}");
            }
        }
    }
}
