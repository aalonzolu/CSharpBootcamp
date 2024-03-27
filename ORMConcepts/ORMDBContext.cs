namespace ORMConcepts;

using Microsoft.EntityFrameworkCore;
using models;



public class OrmdbContext : DbContext
{ 
    public DbSet<Product>? Products { get; set; } 
    public DbSet<Customer>? Customers { get; set; } 
    public DbSet<Order>? Orders { get; set; } 
    public DbSet<OrderDetail>? OrderDetails { get; set; }
    
    public string DbPath { get; }

    public OrmdbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        Console.WriteLine(path);
        DbPath = System.IO.Path.Join(path, "orm.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
