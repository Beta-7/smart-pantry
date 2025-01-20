using Diplomska.Persistence;
using Diplomska.Persistence.Models;

namespace Diplomska.Utils;

public static class DatabaseSeeder
{
    public static void SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<DataContext>();

        // Ensure database is created
        // context.Database.Migrate();

        // Check if the database already has data

        var milkGuid = Guid.NewGuid();
        var butterGuid = Guid.NewGuid();
        var cheeseGuid = Guid.NewGuid();
        var yogurtGuid = Guid.NewGuid();
        var breadGuid = Guid.NewGuid();
        
        if (!context.Products.Any())
        {
            context.Products.AddRange(
                new Product
                {
                    Id = milkGuid,
                    Name = "Milk",
                    Barcode = "123456789012",
                    ExpirationDaysAfterOpen = 7,
                    PackagingWeight = 0.2m,
                    Weight = 1.0m
                },
                new Product
                {
                    Id = butterGuid,
                    Name = "Butter",
                    Barcode = "987654321098",
                    ExpirationDaysAfterOpen = 14,
                    PackagingWeight = 0.1m,
                    Weight = 0.5m
                },
                new Product
                {
                    Id = cheeseGuid,
                    Name = "Cheese",
                    Barcode = "456123789045",
                    ExpirationDaysAfterOpen = 21,
                    PackagingWeight = 0.15m,
                    Weight = 1.5m
                },
                new Product
                {
                    Id = yogurtGuid,
                    Name = "Yogurt",
                    Barcode = "789456123078",
                    ExpirationDaysAfterOpen = 10,
                    PackagingWeight = 0.25m,
                    Weight = 1.2m
                },
                new Product
                {
                    Id = breadGuid,
                    Name = "Bread",
                    Barcode = "321654987065",
                    ExpirationDaysAfterOpen = 5,
                    PackagingWeight = 0.05m,
                    Weight = 0.8m
                }
            );

            context.SaveChanges();
        }
        
        if (!context.OpenProducts.Any())
            {
                context.OpenProducts.AddRange(
                    new OpenProduct
                    {
                        ProductId = milkGuid,
                        RemainingWeight = 0.5m,
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                        OpenDate = DateOnly.FromDateTime(DateTime.Now)
                    },
                    new OpenProduct
                    {
                        ProductId = butterGuid,
                        RemainingWeight = 0.3m,
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                        OpenDate = DateOnly.FromDateTime(DateTime.Now)
                    },
                    new OpenProduct
                    {
                        ProductId = cheeseGuid,
                        RemainingWeight = 1.0m,
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(15)),
                        OpenDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5))
                    },
                    new OpenProduct
                    {
                        ProductId = yogurtGuid,
                        RemainingWeight = 0.8m,
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                        OpenDate = DateOnly.FromDateTime(DateTime.Now)
                    },
                    new OpenProduct
                    {
                        ProductId = breadGuid,
                        RemainingWeight = 0.4m,
                        ExpirationDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                        OpenDate = DateOnly.FromDateTime(DateTime.Now)
                    }
                );

                context.SaveChanges();
            }
    }
}