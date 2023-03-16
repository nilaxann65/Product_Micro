using Product_Micro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Product_Micro.Core.ProductAggregate;

namespace Product_Micro.Web;

public static class SeedData
{
  
 public static readonly Product Product1 = new("Product 1", 10);
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.Products.Any())
      {
        return;   // DB has been seeded
      }
      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.Products)
    {
      dbContext.Remove(item);
    }

    dbContext.SaveChanges();

    dbContext.Products.Add(Product1);

    dbContext.SaveChanges();

  }
}
