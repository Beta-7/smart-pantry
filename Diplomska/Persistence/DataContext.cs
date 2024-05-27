using Diplomska.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Diplomska.Persistence;

public class DataContext : DbContext
{
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<OpenProduct> OpenProducts { get; set; }
    public DbSet<UnopenedProduct> UnopenedProducts { get; set; }
}