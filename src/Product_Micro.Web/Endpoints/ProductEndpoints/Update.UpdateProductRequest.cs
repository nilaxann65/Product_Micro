using Microsoft.Build.Framework;

namespace Product_Micro.Web.Endpoints.ProductEndpoints;

public class UpdateProductRequest
{
  public const string Route = "/Products";
  public int Id { get; set; }
  public string Name { get; set; } = null!;
  public decimal Price { get; set; }
}
